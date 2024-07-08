using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Shop.Application.Behaviors;

namespace Shop.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            var assembly = typeof(DependencyInjection).Assembly;

            services.AddMediatR(configuration =>
            {
                configuration.AddOpenBehavior(typeof(RequestLoggingPipelineBehavior<,>));
                configuration.RegisterServicesFromAssemblies(assembly);
            });


            services.AddValidatorsFromAssembly(assembly);

            return services;
        }
    }
}
