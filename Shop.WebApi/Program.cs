using Shop.Application;
using Serilog;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure;
using Shop.Persistence;
using Shop.Presentation;
using Shop.Persistence.Database;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ShopDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ShopConnection")));

System.Reflection.Assembly presentationAssembly = typeof(Shop.Presentation.AssemblyReference).Assembly;

builder.Services.AddControllers().AddApplicationPart(presentationAssembly);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services
    .AddApplication()
    .AddInfrastructure()
    .AddPersistence()
    .AddPresentation();

builder.Host.UseSerilog((context, configuration) =>
    configuration.ReadFrom.Configuration(context.Configuration));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSerilogRequestLogging();

app.UseHttpsRedirection();

//app.UseAuthorization();

app.MapControllers();

app.Run();
