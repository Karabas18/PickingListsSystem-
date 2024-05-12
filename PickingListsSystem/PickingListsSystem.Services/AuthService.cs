using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using PickingListsSystem.DataAccess.Contracts;
using PickingListsSystem.Dto.Enums;
using PickingListsSystem.Dto.Infrastructure;
using PickingListsSystem.Dto.User;
using PickingListsSystem.Entities;
using PickingListsSystem.Services.Contracts;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;

namespace PickingListsSystem.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly AppSettings _appSettings;
        private readonly IUserRefreshTokenRepository _userRefreshTokenRepository;

        public AuthService(UserManager<User> userManager, SignInManager<User> signInManager, IOptions<AppSettings> appSettings, IUserRefreshTokenRepository userRefreshTokenRepository)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _appSettings = appSettings.Value;
            _userRefreshTokenRepository = userRefreshTokenRepository;
        }

        public async Task<LoginResponse> Login(LoginRequest request)
        {
            var (validationResult, errorMessage, user) = await ValidateLogin(request);

            if (validationResult != AuthResultTypeEnum.Success || user == null)
            {
                return new LoginResponse(false, errorMessage);
            }

            var token = await GenerateAccessToken(user);
            var refreshToken = await ChangeRefreshToken(user.Id.ToString());

            return new LoginResponse
            {
                AccessToken = token,
                RefreshToken = refreshToken,
                Message = "Login Successful",
                Email = user.Email!,
                Success = true,
                UserId = user.Id.ToString()
            };
        }

        public async Task<RegisterResponse> Register(RegisterRequest request)
        {
            try
            {
                var user = await _userManager.FindByEmailAsync(request.Email);
                if (user != null) return new RegisterResponse { Message = "User already exists", Success = false };

                user = new User
                {
                    Fullname = request.FullName,
                    Email = request.Email,
                    ConcurrencyStamp = Guid.NewGuid().ToString(),
                    UserName = request.Email,
                };

                var createUserResult = await _userManager.CreateAsync(user, request.Password);
                if (!createUserResult.Succeeded) return new RegisterResponse { Message = $"Create user failed {createUserResult?.Errors?.First()?.Description}", Success = false };

                var addUserToRoleResult = await _userManager.AddToRoleAsync(user, UserRoleEnum.user.ToString());
                if (!addUserToRoleResult.Succeeded) return new RegisterResponse { Message = $"Create user succeeded but could not add user to role {addUserToRoleResult?.Errors?.First()?.Description}", Success = false };

                return new RegisterResponse { Success = true, Message = "User registered successfully" };
            }
            catch (Exception ex)
            {
                return new RegisterResponse { Message = ex.Message, Success = false };
            }
        }

        public async Task<UserDto?> GetProfile(string userId)
        {
            var result = await _userManager.FindByIdAsync(userId);
            return result != null ? new UserDto()
            {
                Id = result.Id,
                Email = result?.Email,
                Fullname = result?.Fullname,
            } : null;
        }

        public async Task<LoginResponse> Refresh(RefreshTokenRequest dto)
        {
            var principal = GetPrincipalFromExpiredToken(dto.AuthenticationToken);
            if (principal == null)
            {
                return new LoginResponse(false, "Not valid token");
            }

            var currentUserId = principal.Claims.FirstOrDefault(_ => _.Type == ClaimTypes.NameIdentifier)?.Value;

            if (currentUserId == null)
            {
                return new LoginResponse(false, "User not found");
            }

            var (validationResult, errorMessage, user) = await ValidateRefresh(currentUserId, dto.RefreshToken);
            if (validationResult != AuthResultTypeEnum.Success || user == null)
            {
                return new LoginResponse(false, errorMessage);
            }

            var token = await GenerateAccessToken(user);
            var refreshToken = await SlideRefreshToken(currentUserId, dto.RefreshToken);

            return new LoginResponse
            {
                AccessToken = token,
                RefreshToken = refreshToken,
                Message = "Login Successful",
                Email = user.Email!,
                Success = true,
                UserId = user.Id.ToString()
            };
        }

        private async Task<(AuthResultTypeEnum ValidationResult, string Message, User? user)> ValidateLogin(LoginRequest request)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);

            if (user == null)
            {
                return (AuthResultTypeEnum.BadRequest, "Bad request", null);
            }

            var signInResult = await _signInManager.CheckPasswordSignInAsync(user, request.Password, true);
            if (signInResult.IsLockedOut)
            {
                return (AuthResultTypeEnum.Lockout, "User is temporarily locked out", null);
            }

            if (!signInResult.Succeeded)
            {
                return (AuthResultTypeEnum.BadRequest, "Bad request", null);
            }

            return (AuthResultTypeEnum.Success, string.Empty, user);
        }

        private async Task<(AuthResultTypeEnum ValidationResult, string Message, User? user)> ValidateRefresh(string userId, string token)
        {
            var user = await _userManager.FindByIdAsync(userId);

            if (user == null)
            {
                return (AuthResultTypeEnum.BadRequest, "Bad request", null);
            }

            var now = DateTime.UtcNow;

            var userRefreshToken = await _userRefreshTokenRepository.GetByUserIdAndTokenAsync(userId, token);

            if (!(userRefreshToken != null && userRefreshToken.ExpiresUtc > now))
            {
                return (AuthResultTypeEnum.Unauthorized, "Not valid refresh token", null);
            }

            var canSignIn = await _signInManager.CanSignInAsync(user);
            if (!canSignIn)
            {
                return (AuthResultTypeEnum.Forbidden, "CanNotSignIn", null);
            }

            var isLocked = await _userManager.IsLockedOutAsync(user);
            if (isLocked)
            {
                return (AuthResultTypeEnum.Lockout, "Temporarily locked out", null);
            }

            return (AuthResultTypeEnum.Success, string.Empty, user);
        }

        public ClaimsPrincipal? GetPrincipalFromExpiredToken(string token)
        {
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateAudience = false,
                ValidateIssuer = false,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = _appSettings.JwtSettings.GetSymmetricSecurityKey(),
                RequireSignedTokens = true,
                ValidateLifetime = false
            };

            try
            {
                if (string.IsNullOrEmpty(token))
                {
                    return null;
                }

                var tokenHandler = new JwtSecurityTokenHandler();
                var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out var securityToken);
                var jwtSecurityToken = securityToken as JwtSecurityToken;
                if (jwtSecurityToken == null || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256,
                        StringComparison.InvariantCultureIgnoreCase))
                {
                    return null;
                }

                return principal;
            }
            catch (Exception)
            {
                return null;
            }
        }

        private async Task<string> GenerateAccessToken(User user)
        {
            var claims = new List<Claim>
            {
                new(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new(ClaimTypes.Name, user.UserName),
                new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new(ClaimTypes.NameIdentifier, user.Id.ToString()),
            };

            var roles = await _userManager.GetRolesAsync(user);
            var roleClaims = roles.Select(x => new Claim(ClaimTypes.Role, x));
            claims.AddRange(roleClaims);

            var key = _appSettings.JwtSettings.GetSymmetricSecurityKey();
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddMinutes(_appSettings.JwtSettings.Lifetime);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: expires,
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private async Task<string> ChangeRefreshToken(string userId)
        {
            var refreshToken = GenerateRefreshToken();

            var expiresDate = DateTime.UtcNow;

            var newRefreshToken = new UserRefreshToken
            {
                IssuedUtc = expiresDate,
                ExpiresUtc = _appSettings.JwtSettings.GetRefreshLifetime(expiresDate),
                RefreshToken = refreshToken,
                UserId = userId,
            };

            await _userRefreshTokenRepository.CreateAsync(newRefreshToken);

            var expiredTokensToDelete = await _userRefreshTokenRepository.GetExpiredByUserIdAsync(userId);

            await _userRefreshTokenRepository.DeleteAsync(expiredTokensToDelete.Select(x => x.Id.ToString()).ToList());

            return refreshToken;
        }

        private static string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomNumber);
            return Convert.ToBase64String(randomNumber);
        }

        private async Task<string> SlideRefreshToken(string userId, string token)
        {
            var tokenToUpdate = await _userRefreshTokenRepository.GetByUserIdAndTokenAsync(userId, token)
                ?? throw new Exception("Not valid refresh token");

            tokenToUpdate.ExpiresUtc = _appSettings.JwtSettings.GetRefreshLifetime(DateTime.UtcNow);
            tokenToUpdate.RefreshToken = GenerateRefreshToken();

            await _userRefreshTokenRepository.UpdateAsync(tokenToUpdate);
            return tokenToUpdate.RefreshToken;
        }
    }
}