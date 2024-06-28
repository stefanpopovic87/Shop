using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace Shop.Presentation.Controllers.Base;

/// <summary>
/// Represents the base API controller.
/// </summary>
[ApiController]
[Route("api/[controller]")]
public abstract class BaseApiController : ControllerBase
{
    private ISender? _sender;

    /// <summary>
    /// Gets the sender.
    /// </summary>
    protected ISender? Sender => _sender ??= HttpContext.RequestServices.GetService<ISender>();
    protected CancellationToken CancellationToken => HttpContext.RequestAborted;
}