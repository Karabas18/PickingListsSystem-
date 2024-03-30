using Microsoft.EntityFrameworkCore;
using PickingListsSystem.DataAccess;
using PickingListsSystem.DataAccess.Contracts;
using PickingListsSystem.DataAccess.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("Default");
Console.WriteLine(connectionString);
if (string.IsNullOrEmpty(connectionString))
{
    
    throw new ApplicationException("Could not load 'Default' connection string");
}

builder.Services.AddDbContext<PlsDbContext>(options =>
            options.UseSqlServer(connectionString));

builder.Services.AddScoped<IMaterialRepository, MaterialRepository>(); //scoped singelton transient

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.Services.MigratePls();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
