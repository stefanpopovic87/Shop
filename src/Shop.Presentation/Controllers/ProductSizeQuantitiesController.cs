using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.ProductSizeQuantites.Create;
using Shop.Application.ProductSizeQuantites.Update;
using Shop.Application.ProductSizeQuantites.Delete;
using Shop.Presentation.Controllers.Base;
using Swashbuckle.AspNetCore.Annotations;
using Mapster;
using Microsoft.AspNetCore.Http;
using Shop.Common;
using Shop.Application.ProductSizeQuantites.Get;

namespace Shop.Presentation.Controllers
{
    [Route("api/productsizequantities")]
    public sealed class ProductSizeQuantitiesController : BaseApiController
    {
        private readonly IMediator _mediator;

        public ProductSizeQuantitiesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("product/{productId}/size/{sizeId}")]
        [SwaggerOperation(
            Summary = "Get product size quantity by product Id and size Id",
            Description = "Retrieves a product size quantity by product Id and size Id.")]
        public async Task<IActionResult> GetProductSizeQuantityById(int productId, int sizeId)
        {
            var query = new GetProductSizeQuantityByIdQuery(productId, sizeId);
            var result = await _mediator.Send(query, CancellationToken);

            if (!result.IsSuccess)
            {
                return NotFound(new { Message = result });
            }

            return Ok(result);
        }

        [HttpPost]
        [SwaggerOperation(
            Summary = "Create a new product size quantity",
            Description = "Creates a new product size quantity.")]
        [ProducesResponseType(typeof(int), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ErrorResult), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateProductSizeQuantity([FromBody] CreateProductSizeQuantityRequest request)
        {
            var command = request.Adapt<CreateProductSizeQuantityCommand>();
            var result = await _mediator.Send(command, CancellationToken);
            if (!result.IsSuccess)
            {
                return BadRequest(new { Message = result });
            }

            return CreatedAtAction(nameof(GetProductSizeQuantityById), new { productId = result.Value.ProductId, sizeId = result.Value.SizeId }, result.Value);
        }

        [HttpPut("{productId}")]
        [SwaggerOperation(
            Summary = "Update a product size quantity",
            Description = "Updates an existing product size quantity.")]
        public async Task<IActionResult> UpdateProductSizeQuantity(int productId, [FromBody] UpdateProductSizeQuantityRequest request)
        {
            var command = request.Adapt<UpdateProductSizeQuantityCommand>() with { ProductId = productId };

            var result = await _mediator.Send(command, CancellationToken);

            if (!result.IsSuccess)
            {
                return BadRequest(new { Message = result });
            }

            return NoContent();
        }

        [HttpPut("{productId}/activate")]
        [SwaggerOperation(
            Summary = "Activate a product size quantity",
            Description = "Activate a deleted product size quantity.")]
        [ProducesResponseType(typeof(Result<int>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(Result<int>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ActivateProductSizeQuantity(int productId, [FromBody] UpdateProductSizeQuantityRequest request)
        {
            var command = request.Adapt<ActivateProductSizeQuantityCommand>() with { ProductId = productId };

            var result = await _mediator.Send(command, CancellationToken);

            if (!result.IsSuccess)
            {
                return BadRequest(new { Message = result });
            }

            return NoContent();
        }

        [HttpDelete("{productId}")]
        [SwaggerOperation(
            Summary = "Delete a product size quantity",
            Description = "Deletes an existing product size quantity by its ID.")]
        public async Task<IActionResult> DeleteProductSizeQuantity(int productId, [FromBody] int sizeId)
        {
            var command = new DeleteProductSizeQuantityCommand(productId, sizeId);
            var result = await _mediator.Send(command, CancellationToken);

            if (!result.IsSuccess)
            {
                return NotFound(new { Message = result });
            }

            return NoContent();
        }
    }
}
