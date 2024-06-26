using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.ProductSize.Create;
using Shop.Application.ProductSize.Delete;
using Shop.Application.ProductSize.Get;
using Shop.Application.ProductSize.List;
using Shop.Application.ProductSize.Update;
using Shop.Presentation.Controllers.Base;
using Swashbuckle.AspNetCore.Annotations;

namespace Shop.Presentation.Controllers
{
    public class ProductSizeController : ApiController
    {
        private readonly IMediator _mediator;

        public ProductSizeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{productId}/{sizeId}")]
        [SwaggerOperation(
            Summary = "Get product size by Product ID and Size ID", 
            Description = "Gets the size of a product by its Product ID and Size ID")]
        public async Task<IActionResult> GetProductSizeById(int productId, int sizeId)
        {
            var query = new GetProductSizeByIdQuery(productId, sizeId);
            var result = await _mediator.Send(query);

            if (!result.IsSuccess)
            {
                return NotFound(new { Message = result.Error });
            }

            return Ok(result);
        }

        [HttpGet("{productId}")]
        [SwaggerOperation(
            Summary = "Get all product sizes by Product ID", 
            Description = "Gets all sizes of a product by its Product ID")]
        public async Task<IActionResult> GetAllByProductId(int productId)
        {
            var query = new GetByIdProductSizeQuery(productId);
            var result = await _mediator.Send(query);

            if (!result.IsSuccess)
            {
                return NotFound(new { Message = result.Error });
            }

            return Ok(result);
        }

        [HttpPost]
        [SwaggerOperation(
            Summary = "Create a new product size", 
            Description = "Creates a new size for a product")]
        public async Task<IActionResult> CreateProductSize([FromBody] CreateProductSizeCommand command)
        {
            var result = await _mediator.Send(command);
            if (!result.IsSuccess)
            {
                return BadRequest(new { Message = result.Error });
            }

            return CreatedAtAction(nameof(GetAllByProductId), new { id = result.Value }, result.Value);
        }

        [HttpPut]
        [SwaggerOperation(
            Summary = "Update product size quantity in stock", 
            Description = "Update product size quantity in stock")]
        public async Task<IActionResult> UpdateProductSize([FromBody] UpdateProductSizeCommand command)
        {
            var result = await _mediator.Send(command);
            if (!result.IsSuccess)
            {
                return NotFound(new { Message = result.Error });
            }
            return NoContent();
        }

        [HttpDelete("{productId}/{sizeId}")]
        [SwaggerOperation(
            Summary = "Delete product size", 
            Description = "Deletes the size of a product")]
        public async Task<IActionResult> DeleteProductSize(int productId, int sizeId)
        {
            var command = new DeleteProductSizeCommand(productId, sizeId);
            var result = await _mediator.Send(command);

            if (!result.IsSuccess)
            {
                return NotFound(new { Message = result.Error });
            }

            return NoContent();
        }

    }
}
