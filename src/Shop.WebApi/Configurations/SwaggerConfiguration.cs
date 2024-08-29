using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Shop.Common;

namespace Shop.Configurations
{
    public static class SwaggerConfiguration
    {
        public static void AddSwaggerConfiguration(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo 
                { 
                    Title = "SHOP API - DEVELOPMENT ENV",
                    Description = "Web Shop app for products, orders and payments",
                    Version = "v1" 
                });

                c.EnableAnnotations();

                //c.MapType<Result<object>>(() => new OpenApiSchema
                //{
                //    Type = "object",
                //    Properties = new Dictionary<string, OpenApiSchema>
                //    {
                //        ["isSuccess"] = new OpenApiSchema { Type = "boolean" },
                //        ["value"] = new OpenApiSchema { Type = "object", Nullable = true },
                //        ["error"] = new OpenApiSchema { Type = "object", Nullable = true }
                //    },
                //    Required = new HashSet<string> { "isSuccess" }
                //});

                c.MapType<ErrorResult>(() => new OpenApiSchema
                {
                    Type = "object",
                    Properties = new Dictionary<string, OpenApiSchema>
                    {
                        ["isSuccess"] = new OpenApiSchema { Type = "boolean", Default = new OpenApiBoolean(false) },
                        ["value"] = new OpenApiSchema { Type = "object", Nullable = true },
                        ["error"] = new OpenApiSchema
                        {
                            Type = "object",
                            Properties = new Dictionary<string, OpenApiSchema>
                            {
                                ["code"] = new OpenApiSchema { Type = "string" },
                                ["description"] = new OpenApiSchema { Type = "string" }
                            }
                        }
                    },
                    Required = new HashSet<string> { "isSuccess", "error" }
                });
            });
        }
    }
}
