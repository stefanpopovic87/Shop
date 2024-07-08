using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Shop.Presentation.Middlewere
{
    public class ExeptionHandlingMiddlewere
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExeptionHandlingMiddlewere> _logger;

        public ExeptionHandlingMiddlewere(
            RequestDelegate next, 
            ILogger<ExeptionHandlingMiddlewere> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }

            catch (Exception exeption)
            {
                _logger.LogError(exeption, $"Exeption occured: {exeption.Message}");

                var problemDetails = new ProblemDetails
                {
                    Status = StatusCodes.Status500InternalServerError,
                    Title = "Server Error",
                    Type = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.6.1"
                };

                context.Response.StatusCode = StatusCodes.Status500InternalServerError;

                await context.Response.WriteAsJsonAsync(problemDetails);

            }
        }

    }
}
