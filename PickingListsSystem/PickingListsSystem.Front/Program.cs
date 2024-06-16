using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using PickingListsSystem.Front;
using MudBlazor.Services;
using PickingListsSystem.Services.Contracts;
using PickingListsSystem.Front.Services;

using PickingListsSystem.Services;
using Microsoft.AspNetCore.Components.Authorization;
using Blazored.LocalStorage;
using BlazorFileSaver;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient 
{ BaseAddress = new Uri("https://localhost:7153/") });

builder.Services.AddBlazoredLocalStorage();

builder.Services.AddBlazorFileSaver();

builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();
builder.Services.AddScoped<IAuthService, AuthService>();

builder.Services.AddMudServices();

builder.Services.AddScoped<IMaterialService, MaterialService>();
builder.Services.AddScoped<IWorkService, WorkService>();
builder.Services.AddScoped<IStatementService, StatementService>();

builder.Services.AddScoped<IProjectService, ProjectService>();

builder.Services.AddSingleton<MarkMaterialService>();
builder.Services.AddSingleton<MarkWorkService>();
builder.Services.AddScoped<StatementService>();

builder.Services.AddScoped<SelectedItemsService>();

builder.Services.AddScoped<IWorkTypeService, WorkTypeService>();

builder.Services.AddScoped<ICustomerService, CustomerService>();

await builder.Build().RunAsync();

