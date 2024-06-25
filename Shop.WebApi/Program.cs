using Shop.Application;
using Serilog;
using Shop.Infrastructure;
using Shop.Persistence;
using Shop.Presentation;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        System.Reflection.Assembly presentationAssembly = typeof(Shop.Presentation.AssemblyReference).Assembly;

        builder.Services.AddControllers().AddApplicationPart(presentationAssembly);
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services
            .AddApplication()
            .AddInfrastructure()
            .AddPersistence(builder.Configuration)
            .AddPresentation();

        builder.Host.UseSerilog((context, configuration) =>
            configuration.ReadFrom.Configuration(context.Configuration));

        builder.Services.AddHealthChecks();

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.MapHealthChecks("health");

        app.UseSerilogRequestLogging();

        app.UseHttpsRedirection();

        //app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}