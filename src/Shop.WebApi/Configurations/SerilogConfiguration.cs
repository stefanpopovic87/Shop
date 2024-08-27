using Serilog.Events;
using Serilog;

namespace Shop.WebApi.Configurations
{
    public static class SerilogConfiguration
    {
        public static void ConfigureLogger()
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Information()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
                .MinimumLevel.Override("System", LogEventLevel.Warning)
                .Enrich.FromLogContext()
                .WriteTo.Console()
                .WriteTo.File("logs/shoplog.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();
        }
    }
}
