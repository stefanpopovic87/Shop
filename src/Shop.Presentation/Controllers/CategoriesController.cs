using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.Category.Create;
using Shop.Application.Category.Get;
using Shop.Application.Category.List;
using Shop.Presentation.Controllers.Base;
using Swashbuckle.AspNetCore.Annotations;
using Mapster;
using Shop.Application.Category.Update;
using Shop.Application.Category.Delete;
using Microsoft.AspNetCore.Http;
using Shop.Common;

namespace Shop.Presentation.Controllers
{
    [Route("api/categories")]
    public sealed class CategoriesController : BaseApiController
    {
        private readonly IMediator _mediator;

        public CategoriesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [SwaggerOperation(
            Summary = "Get all categories",
            Description = "Retrieves a list of all categories")]
        [Produces("application/json")]
        public async Task<IActionResult> GetCategories()
        {
            var query = new GetCategoriesQuery();

            var result = await _mediator.Send(query, CancellationToken);

            if (!result.IsSuccess)
            {
                return NotFound(new { Message = result });
            }

            return Ok(result);
        }

        [HttpGet("{id}")]
        [SwaggerOperation(
            Summary = "Get category by ID",
            Description = "Retrieves a category by its Id")]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            var query = new GetCategoryByIdQuery(id);
            var result = await _mediator.Send(query, CancellationToken);

            if (!result.IsSuccess)
            {
                return NotFound(new { Message = result });
            }

            return Ok(result);
        }

        [HttpPost]
        [SwaggerOperation(
            Summary = "Create a new category",
            Description = "Creates a new category")]
        [ProducesResponseType(typeof(int), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ErrorResult), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryRequest request)
        {
            var command = request.Adapt<CreateCategoryCommand>();
            var result = await _mediator.Send(command, CancellationToken);
            if (!result.IsSuccess)
            {
                return BadRequest(new { Message = result });
            }

            return CreatedAtAction(nameof(GetCategoryById), new { id = result.Value }, result.Value);
        }

        [HttpPut("{id}")]
        [SwaggerOperation(
            Summary = "Update a category",
            Description = "Updates an existing category")]
        public async Task<IActionResult> UpdateCategory(int id, [FromBody] UpdateCategoryRequest request)
        {
            var command = request.Adapt<UpdateCategoryCommand>() with { Id = id };

            var result = await _mediator.Send(command, CancellationToken);

            if (!result.IsSuccess)
            {
                return BadRequest(new { Message = result });
            }

            return NoContent();
        }

        [HttpPut("{id}/activate")]
        [SwaggerOperation(
            Summary = "Activate a category",
            Description = "Activates a deleted category by its Id")]
        [ProducesResponseType(typeof(Result<int>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(Result<int>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ActivateCategory(int id)
        {
            var command = new ActivateCategoryCommand(id);

            var result = await _mediator.Send(command, CancellationToken);

            if (!result.IsSuccess)
            {
                return BadRequest(new { Message = result });
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        [SwaggerOperation(
            Summary = "Delete a category",
            Description = "Deletes an existing category by its Id")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var command = new DeleteCategoryCommand(id);
            var result = await _mediator.Send(command, CancellationToken);

            if (!result.IsSuccess)
            {
                return NotFound(new { Message = result });
            }

            return NoContent();
        }
    }
}
