using Blazored.LocalStorage;

public interface IAuthService
{
    Task<string> GetTokenAsync();
}

public class AuthService : IAuthService
{
    protected readonly ILocalStorageService _localStorage;

    public AuthService(ILocalStorageService localStorage)
    {
        _localStorage = localStorage;
    }

    public async Task<string> GetTokenAsync()
    {
        return await _localStorage.GetItemAsStringAsync("token");
    }
}