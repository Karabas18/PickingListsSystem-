using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PickingListsSystem.API.Extensions;
using PickingListsSystem.API.Profiles;
using PickingListsSystem.DataAccess;
using PickingListsSystem.DataAccess.Contracts;
using PickingListsSystem.DataAccess.Repositories;
using PickingListsSystem.Dto.Infrastructure;
using PickingListsSystem.Entities;
using PickingListsSystem.Services;
using PickingListsSystem.Services.Contracts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerConfiguration();

builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));
var connectionString = builder.Configuration.GetConnectionString("Default");
Console.WriteLine(connectionString);
if (string.IsNullOrEmpty(connectionString))
{
    
    throw new ApplicationException("Could not load 'Default' connection string");
}

builder.Services.AddDbContext<PlsDbContext>(options =>
            options.UseSqlServer(connectionString));


builder.Services.AddIdentity<User, Role>()
        .AddEntityFrameworkStores<PlsDbContext>()
        .AddUserManager<UserManager<User>>()
        .AddSignInManager<SignInManager<User>>()
        .AddRoleManager<RoleManager<Role>>()
        .AddDefaultTokenProviders();

builder.Services.AddAuthConfiguration(builder.Configuration);


builder.Services.AddScoped<IAuthService, AuthService>(); 
builder.Services.AddScoped<IUserRefreshTokenRepository, UserRefreshTokenRepository>();
builder.Services.AddScoped<IMaterialRepository, MaterialRepository>(); //scoped singelton transient
builder.Services.AddScoped<IMaterialService, MaterialService>();

builder.Services.AddScoped<IWorkRepository, WorkRepository>(); //work
builder.Services.AddScoped<IWorkService, WorkService>();

builder.Services.AddScoped<ICustomerRepository, CustomerRepository>(); //customer
builder.Services.AddScoped<ICustomerService, CustomerService>();

builder.Services.AddScoped<IWorkTypeRepository, WorkTypeRepository>(); //workType
builder.Services.AddScoped<IWorkTypeService, WorkTypeService>();

builder.Services.AddScoped<IRoleRepository, RoleRepository>(); //role
builder.Services.AddScoped<IRoleService, RoleService>();

builder.Services.AddScoped<IUserRepository, UserRepository>(); //user
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddScoped<IWorkGroupRepository, WorkGroupRepository>(); //workGroup
builder.Services.AddScoped<IWorkGroupService, WorkGroupService>();

builder.Services.AddScoped<IProjectRepository, ProjectRepository>(); //project
builder.Services.AddScoped<IProjectService, ProjectService>();

builder.Services.AddScoped<IStatementRepository, StatementRepository>(); //statement
builder.Services.AddScoped<IStatementService, StatementService>();

builder.Services.AddAutoMapper(typeof(MaterialProfile));
//
builder.Services.AddAutoMapper(typeof(WorkProfile));

var app = builder.Build();

app.Services.DbInit();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(x => x.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod());

app.Services.MigratePls();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
