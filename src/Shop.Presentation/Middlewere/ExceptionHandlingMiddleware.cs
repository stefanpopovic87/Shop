using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Shop.Presentation.Middleware
{
    public class ExceptionHandlingMiddleware : IMiddleware
    {
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;

        public ExceptionHandlingMiddleware(
            ILogger<ExceptionHandlingMiddleware> logger)
        {
            _logger = logger;
        }        

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }

            catch (Exception exception)
            {
                _logger.LogError(exception, $"Exception occurred: {exception.Message}");

                var problemDetails = new ProblemDetails
                {
                    Status = StatusCodes.Status500InternalServerError,
                    Title = "Server Error",
                    Type = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.6.1",
                    Detail = "An internal server error has occurred"
                };

                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                context.Response.ContentType = "application/json";

                await context.Response.WriteAsJsonAsync(problemDetails);

            }
        }
    }
}
