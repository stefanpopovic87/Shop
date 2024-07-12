using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;

namespace Shop.WebApi.Configurations
{
    public static class ControllerConfiguration
    {
        public static void AddControllerConfiguration(this IServiceCollection services, System.Reflection.Assembly presentationAssembly)
        {
            services.AddControllers(options =>
            {
                options.Filters.Add(new ProducesAttribute("application/json"));
            }).AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
            }).AddApplicationPart(presentationAssembly);
        }
    }
}
