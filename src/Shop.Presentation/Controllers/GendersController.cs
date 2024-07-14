using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.Gender.Create;
using Shop.Application.Gender.Get;
using Shop.Application.Gender.List;
using Shop.Presentation.Controllers.Base;
using Swashbuckle.AspNetCore.Annotations;
using Mapster;
using Shop.Application.Gender.Update;
using Shop.Application.Gender.Delete;
using Microsoft.AspNetCore.Http;
using Shop.Common;
using Shop.Application.Dtos.Base;

namespace Shop.Presentation.Controllers
{
    [Route("api/genders")]
    public sealed class GendersController : BaseApiController
    {
        private readonly IMediator _mediator;

        public GendersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [SwaggerOperation(
            Summary = "Get all genders",
            Description = "Retrieves a list of all genders.")]
        [Produces("application/json")]
        public async Task<IActionResult> GetGenders()
        {
            var query = new GetGendersQuery();

            var result = await _mediator.Send(query, CancellationToken);

            if (!result.IsSuccess)
            {
                return NotFound(new { Message = result });
            }

            return Ok(result);
        }

        [HttpGet("{id}")]
        [SwaggerOperation(
            Summary = "Get gender by ID",
            Description = "Retrieves a gender by its Id.")]
        public async Task<IActionResult> GetGenderById(int id)
        {
            var query = new GetGenderByIdQuery(id);
            var result = await _mediator.Send(query, CancellationToken);

            if (!result.IsSuccess)
            {
                return NotFound(new { Message = result });
            }

            return Ok(result);
        }

        [HttpPost]
        [SwaggerOperation(
            Summary = "Create a new gender",
            Description = "Creates a new gender.")]
        [ProducesResponseType(typeof(int), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ErrorResult), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateGender([FromBody] CreateGenderRequest request)
        {
            var command = request.Adapt<CreateGenderCommand>();
            var result = await _mediator.Send(command, CancellationToken);
            if (!result.IsSuccess)
            {
                return BadRequest(new { Message = result });
            }

            return CreatedAtAction(nameof(GetGenderById), new { id = result.Value }, result.Value);
        }

        [HttpPut("{id}")]
        [SwaggerOperation(
            Summary = "Update a gender",
            Description = "Updates an existing gender.")]
        public async Task<IActionResult> UpdateGender(int id, [FromBody] UpdateGenderRequest request)
        {
            var command = request.Adapt<UpdateGenderCommand>() with { Id = id };

            var result = await _mediator.Send(command, CancellationToken);

            if (!result.IsSuccess)
            {
                return BadRequest(new { Message = result });
            }

            return NoContent();
        }

        [HttpPut("{id}/activate")]
        [SwaggerOperation(
            Summary = "Activate a gender",
            Description = "Activate a deleted gender.")]
        [ProducesResponseType(typeof(Result<int>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(Result<int>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ActivateGender(int id)
        {
            var command = new ActivateGenderCommand(id);

            var result = await _mediator.Send(command, CancellationToken);

            if (!result.IsSuccess)
            {
                return BadRequest(new { Message = result });
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        [SwaggerOperation(
            Summary = "Delete a gender",
            Description = "Deletes an existing gender by its ID.")]
        public async Task<IActionResult> DeleteGender(int id)
        {
            var command = new DeleteGenderCommand(id);
            var result = await _mediator.Send(command, CancellationToken);

            if (!result.IsSuccess)
            {
                return NotFound(new { Message = result });
            }

            return NoContent();
        }
    }
}
