using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using PickingListsSystem.DataAccess;
using PickingListsSystem.Web;
using Microsoft.EntityFrameworkCore;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

var connectionString = builder.Configuration.GetConnectionString("Default");
var connectionStringIdentity = builder.Configuration.GetConnectionString("Identity");

builder.Services.AddDbContext<PlsDbContext>(options =>
            options.UseSqlServer(connectionString));


await builder.Build().RunAsync();
