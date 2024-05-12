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

//Проверить!!!
builder.Services.AddSingleton<MarkMaterialService>();
//

await builder.Build().RunAsync();

