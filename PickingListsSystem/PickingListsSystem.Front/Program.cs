using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using PickingListsSystem.Front;
using MudBlazor.Services;
using PickingListsSystem.Services.Contracts;
using PickingListsSystem.Front.Services;

//
using PickingListsSystem.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient 
{ BaseAddress = new Uri("https://localhost:7153/") });

builder.Services.AddMudServices();

builder.Services.AddScoped<IMaterialService, MaterialService>();
builder.Services.AddScoped<IWorkService, WorkService>();
builder.Services.AddScoped<IStatementService, StatementService>();

//Проверить!!!
builder.Services.AddSingleton<MarkMaterialService>();
builder.Services.AddSingleton<MarkWorkService>();
builder.Services.AddScoped<StatementService>();

await builder.Build().RunAsync();

