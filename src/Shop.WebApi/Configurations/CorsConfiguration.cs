namespace Shop.WebApi.Configurations
{
    public static class CorsConfiguration
    {

        public static IServiceCollection AddCorsConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            var allowedOrigin = configuration.GetSection("AllowedOrigins:Client").Value
                ?? throw new ArgumentNullException("AllowedOrigins:Client", "The CORS allowed origin is not configured.");

            services.AddCors(options =>
            {
                options.AddPolicy("AllowClient", builder =>
                {
                    builder.WithOrigins(allowedOrigin)
                           .AllowAnyHeader()
                           .AllowAnyMethod();
                });
            });

            return services;
        }
    }
}

