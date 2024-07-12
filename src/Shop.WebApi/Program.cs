using Shop.Application;
using Serilog;
using Shop.Infrastructure;
using Shop.Persistence;
using Shop.Presentation;
using Shop.Presentation.Middleware;
using Shop.Configurations;
using Shop.WebApi.Configurations;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        System.Reflection.Assembly presentationAssembly = typeof(Shop.Presentation.AssemblyReference).Assembly;

        builder.Services.AddControllerConfiguration(presentationAssembly);

        var allowedOrigin = builder.Configuration.GetSection("AllowedOrigins:Client").Value
            ?? throw new ArgumentNullException("AllowedOrigins:Client", "The CORS allowed origin is not configured.");

        builder.Services.AddCors(options =>
        {
            options.AddPolicy("AllowClient", builder =>
            {
                builder.WithOrigins(allowedOrigin)
                       .AllowAnyHeader()
                       .AllowAnyMethod();
            });
        });

        builder.Services.AddEndpointsApiExplorer();

        builder.Services.AddSwaggerConfiguration();


        builder.Host.UseSerilog((context, configuration) =>
            configuration.ReadFrom.Configuration(context.Configuration)
                .WriteTo.Console()
                .WriteTo.File("logs/shoplog.txt", rollingInterval: RollingInterval.Day));

        builder.Services.AddHealthChecks();

        builder.Services
            .AddApplication()
            .AddPersistence(builder.Configuration, builder.Environment)
            .AddPresentation()
            .AddInfrastructure();

        builder.Services.AddTransient<ExceptionHandlingMiddleware>();

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "SHOP API v1");
            });
        }

        app.UseCors("AllowClient");

        app.MapHealthChecks("health");

        app.UseSerilogRequestLogging();

        //app.UseHttpsRedirection();

        //app.UseAuthorization();

        app.UseMiddleware<ExceptionHandlingMiddleware>();

        app.MapControllers();

        app.UseSerilogRequestLogging();

        app.Run();
    }
}