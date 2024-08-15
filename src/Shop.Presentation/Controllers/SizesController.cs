using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.Sizes.Create;
using Shop.Application.Sizes.Get;
using Shop.Application.Sizes.List;
using Shop.Presentation.Controllers.Base;
using Swashbuckle.AspNetCore.Annotations;
using Mapster;
using Shop.Application.Sizes.Update;
using Shop.Application.Sizes.Delete;
using Microsoft.AspNetCore.Http;
using Shop.Common;
using Shop.Application.Dtos.Base;

namespace Shop.Presentation.Controllers
{
    [Route("api/sizes")]
    public sealed class SizesController : BaseApiController
    {
        private readonly IMediator _mediator;

        public SizesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [SwaggerOperation(
            Summary = "Get all sizes",
            Description = "Retrieves a list of all sizes.")]
        [Produces("application/json")]
        public async Task<IActionResult> GetSizes()
        {
            var query = new GetSizesQuery();

            var result = await _mediator.Send(query, CancellationToken);

            if (!result.IsSuccess)
            {
                return NotFound(new { Message = result });
            }

            return Ok(result);
        }

        [HttpGet("category/{id}")]
        [SwaggerOperation(
            Summary = "Get sizes by category Id",
            Description = "Retrieves a list of sizes by category Id.")]
        public async Task<IActionResult> GetSizesByCategoryId(int id)
        {
            var query = new GetSizesByCategoryIdQuery(id);
            var result = await _mediator.Send(query, CancellationToken);

            if (!result.IsSuccess)
            {
                return NotFound(new { Message = result });
            }

            return Ok(result);
        }

        [HttpGet("{id}")]
        [SwaggerOperation(
            Summary = "Get size by ID",
            Description = "Retrieves a size by its Id.")]
        public async Task<IActionResult> GetSizeById(int id)
        {
            var query = new GetSizeByIdQuery(id);
            var result = await _mediator.Send(query, CancellationToken);

            if (!result.IsSuccess)
            {
                return NotFound(new { Message = result });
            }

            return Ok(result);
        }

        [HttpPost]
        [SwaggerOperation(
            Summary = "Create a new size",
            Description = "Creates a new size.")]
        [ProducesResponseType(typeof(int), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ErrorResult), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateSize([FromBody] CreateSizeRequest request)
        {
            var command = request.Adapt<CreateSizeCommand>();
            var result = await _mediator.Send(command, CancellationToken);
            if (!result.IsSuccess)
            {
                return BadRequest(new { Message = result });
            }

            return CreatedAtAction(nameof(GetSizeById), new { id = result.Value }, result.Value);
        }

        [HttpPut("{id}")]
        [SwaggerOperation(
            Summary = "Update a size",
            Description = "Updates an existing size.")]
        public async Task<IActionResult> UpdateSize(int id, [FromBody] UpdateSizeRequest request)
        {
            var command = request.Adapt<UpdateSizeCommand>() with { Id = id };

            var result = await _mediator.Send(command, CancellationToken);

            if (!result.IsSuccess)
            {
                return BadRequest(new { Message = result });
            }

            return NoContent();
        }


        [HttpPut("{id}/activate")]
        [SwaggerOperation(
            Summary = "Activate a size",
            Description = "Activates a deleted size by its Id")]
        [ProducesResponseType(typeof(Result<int>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(Result<int>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ActivateSize(int id)
        {
            var command = new ActivateSizeCommand(id);

            var result = await _mediator.Send(command, CancellationToken);

            if (!result.IsSuccess)
            {
                return BadRequest(new { Message = result });
            }

            return NoContent();
        }


        [HttpDelete("{id}")]
        [SwaggerOperation(
            Summary = "Delete a size",
            Description = "Deletes an existing size by its Id")]
        public async Task<IActionResult> DeleteSize(int id)
        {
            var command = new DeleteSizeCommand(id);
            var result = await _mediator.Send(command, CancellationToken);

            if (!result.IsSuccess)
            {
                return NotFound(new { Message = result });
            }

            return NoContent();
        }
    }
}
