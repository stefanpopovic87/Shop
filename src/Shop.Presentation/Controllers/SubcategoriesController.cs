using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.Subcategory.Create;
using Shop.Application.Subcategory.Get;
using Shop.Application.Subcategory.List;
using Shop.Presentation.Controllers.Base;
using Swashbuckle.AspNetCore.Annotations;
using Mapster;
using Shop.Application.Subcategory.Update;
using Shop.Application.Subcategory.Delete;
using Microsoft.AspNetCore.Http;
using Shop.Common;
using Shop.Application.Size.List;

namespace Shop.Presentation.Controllers
{
    [Route("api/subcategories")]
    public sealed class SubcategoriesController : BaseApiController
    {
        private readonly IMediator _mediator;

        public SubcategoriesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [SwaggerOperation(
            Summary = "Get all subcategories",
            Description = "Retrieves a list of all subcategories.")]
        [Produces("application/json")]
        public async Task<IActionResult> GetSubcategories()
        {
            var query = new GetSubcategoriesQuery();

            var result = await _mediator.Send(query, CancellationToken);

            if (!result.IsSuccess)
            {
                return NotFound(new { Message = result });
            }

            return Ok(result);
        }

        [HttpGet("category/{id}")]
        [SwaggerOperation(
           Summary = "Get subcategories by category Id",
           Description = "Retrieves a list of subcategories by category Id.")]
        public async Task<IActionResult> GetSubcategoriesByCategoryId(int id)
        {
            var query = new GetSubcategoriesByCategoryIdQuery(id);
            var result = await _mediator.Send(query, CancellationToken);

            if (!result.IsSuccess)
            {
                return NotFound(new { Message = result });
            }

            return Ok(result);
        }

        [HttpGet("{id}")]
        [SwaggerOperation(
            Summary = "Get subcategory by ID",
            Description = "Retrieves a subcategory by its Id.")]
        public async Task<IActionResult> GetSubcategoryById(int id)
        {
            var query = new GetSubcategoryByIdQuery(id);
            var result = await _mediator.Send(query, CancellationToken);

            if (!result.IsSuccess)
            {
                return NotFound(new { Message = result });
            }

            return Ok(result);
        }

        [HttpPost]
        [SwaggerOperation(
            Summary = "Create a new subcategory",
            Description = "Creates a new subcategory.")]
        [ProducesResponseType(typeof(int), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ErrorResult), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateSubcategory([FromBody] CreateSubcategoryRequest request)
        {
            var command = request.Adapt<CreateSubcategoryCommand>();
            var result = await _mediator.Send(command, CancellationToken);
            if (!result.IsSuccess)
            {
                return BadRequest(new { Message = result });
            }

            return CreatedAtAction(nameof(GetSubcategoryById), new { id = result.Value }, result.Value);
        }

        [HttpPut("{id}")]
        [SwaggerOperation(
            Summary = "Update a subcategory",
            Description = "Updates an existing subcategory.")]
        public async Task<IActionResult> UpdateSubcategory(int id, [FromBody] UpdateSubcategoryRequest request)
        {
            var command = request.Adapt<UpdateSubcategoryCommand>() with { Id = id };

            var result = await _mediator.Send(command, CancellationToken);

            if (!result.IsSuccess)
            {
                return BadRequest(new { Message = result });
            }

            return NoContent();
        }

        [HttpPut("{id}/activate")]
        [SwaggerOperation(
            Summary = "Activate a subcategory",
            Description = "Activates a deleted subcategory by its Id")]
        [ProducesResponseType(typeof(Result<int>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(Result<int>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ActivateSubcategory(int id)
        {
            var command = new ActivateSubcategoryCommand(id);

            var result = await _mediator.Send(command, CancellationToken);

            if (!result.IsSuccess)
            {
                return BadRequest(new { Message = result });
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        [SwaggerOperation(
            Summary = "Delete a subcategory",
            Description = "Deletes an existing subcategory by its Id")]
        public async Task<IActionResult> DeleteSubcategory(int id)
        {
            var command = new DeleteSubcategoryCommand(id);
            var result = await _mediator.Send(command, CancellationToken);

            if (!result.IsSuccess)
            {
                return NotFound(new { Message = result });
            }

            return NoContent();
        }
    }
}
