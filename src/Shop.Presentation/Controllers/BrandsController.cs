using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.Brands.Create;
using Shop.Application.Brands.Get;
using Shop.Application.Brands.List;
using Shop.Presentation.Controllers.Base;
using Swashbuckle.AspNetCore.Annotations;
using Mapster;
using Shop.Application.Brands.Update;
using Shop.Application.Brands.Delete;
using Microsoft.AspNetCore.Http;
using Shop.Common;

namespace Shop.Presentation.Controllers
{
    [Route("api/brands")]
    public sealed class BrandsController : BaseApiController
    {
        private readonly IMediator _mediator;

        public BrandsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [SwaggerOperation(
            Summary = "Get all brands",
            Description = "Retrieves a list of all brands")]
        [Produces("application/json")]
        public async Task<IActionResult> GetBrands()
        {
            var query = new GetBrandsQuery();

            var result = await _mediator.Send(query, CancellationToken);

            if (!result.IsSuccess)
            {
                return NotFound(new { Message = result });
            }

            return Ok(result);
        }

        [HttpGet("{id}")]
        [SwaggerOperation(
            Summary = "Get brand by ID",
            Description = "Retrieves a brand by its Id")]
        public async Task<IActionResult> GetBrandById(int id)
        {
            var query = new GetBrandByIdQuery(id);
            var result = await _mediator.Send(query, CancellationToken);

            if (!result.IsSuccess)
            {
                return NotFound(new { Message = result });
            }

            return Ok(result);
        }

        [HttpPost]
        [SwaggerOperation(
            Summary = "Create a new brand",
            Description = "Creates a new brand")]
        [ProducesResponseType(typeof(int), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ErrorResult), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateBrand([FromBody] CreateBrandRequest request)
        {
            var command = request.Adapt<CreateBrandCommand>();
            var result = await _mediator.Send(command, CancellationToken);
            if (!result.IsSuccess)
            {
                return BadRequest(new { Message = result });
            }

            return CreatedAtAction(nameof(GetBrandById), new { id = result.Value }, result.Value);
        }

        [HttpPut("{id}")]
        [SwaggerOperation(
            Summary = "Update a brand",
            Description = "Updates an existing brand")]
        public async Task<IActionResult> UpdateBrand(int id, [FromBody] UpdateBrandRequest request)
        {
            var command = request.Adapt<UpdateBrandCommand>() with { Id = id };

            var result = await _mediator.Send(command, CancellationToken);

            if (!result.IsSuccess)
            {
                return BadRequest(new { Message = result });
            }

            return NoContent();
        }


        [HttpPut("{id}/activate")]
        [SwaggerOperation(
            Summary = "Activate a brand",
            Description = "Activates a deleted brand by its Id")]
        [ProducesResponseType(typeof(Result<int>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(Result<int>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ActivateBrand(int id)
        {
            var command = new ActivateBrandCommand(id);

            var result = await _mediator.Send(command, CancellationToken);

            if (!result.IsSuccess)
            {
                return BadRequest(new { Message = result });
            }

            return NoContent();
        }


        [HttpDelete("{id}")]
        [SwaggerOperation(
            Summary = "Delete a brand",
            Description = "Deletes an existing brand by its Id")]
        public async Task<IActionResult> DeleteBrand(int id)
        {
            var command = new DeleteBrandCommand(id);
            var result = await _mediator.Send(command, CancellationToken);

            if (!result.IsSuccess)
            {
                return NotFound(new { Message = result });
            }

            return NoContent();
        }
    }
}
