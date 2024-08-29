using Shop.Application;
using Serilog;
using Shop.Infrastructure;
using Shop.Persistence;
using Shop.Presentation;
using Shop.Configurations;
using Shop.WebApi.Configurations;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        var env = builder.Environment;

        builder.Services.AddControllerConfiguration();

        builder.Services.AddCorsConfiguration(builder.Configuration);

        builder.Services.AddEndpointsApiExplorer();

        builder.Services.AddSwaggerConfiguration();

        builder.Host.UseSerilog((context, configuration) =>
            configuration.ReadFrom.Configuration(context.Configuration));

        builder.Services.AddHealthChecks();

        builder.Services
            .AddApplication()
            .AddPersistence(builder.Configuration, builder.Environment)
            .AddPresentation()
            .AddInfrastructure();

        //builder.Services.AddTransient<ExceptionHandlingMiddleware>();

        var app = builder.Build();

        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "SHOP API v1");
        });

        app.UseCors("AllowClient");

        app.MapHealthChecks("health");

        app.UseSerilogRequestLogging();

        //app.UseHttpsRedirection();

        //app.UseAuthorization();

        //app.UseMiddleware<ExceptionHandlingMiddleware>();

        app.MapControllers();              

        app.Run();
    }
}