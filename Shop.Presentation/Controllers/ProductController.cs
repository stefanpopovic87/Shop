using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.Product.Create;
using Shop.Application.Product.Delete;
using Shop.Application.Product.Get;
using Shop.Application.Product.Update;
using Shop.Presentation.Controllers.Base;

namespace Shop.Presentation.Controllers
{
    public class ProductController : ApiController
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var query = new GetProductsQuery();
            var result = await _mediator.Send(query);

            if (result is null)
            {
                return NotFound(new { Message = result.Error });
            }

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var query = new GetByIdProductQuery(id);
            var result = await _mediator.Send(query);

            if (!result.IsSuccess)
            {
                return NotFound(new { Message = result.Error });
            }

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] CreateProductCommand command)
        {
            var result = await _mediator.Send(command);
            if (!result.IsSuccess)
            {
                return BadRequest(new { Message = result.Error });
            }

            return CreatedAtAction(nameof(GetProductById), new { id = result.Value }, result.Value);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var command = new DeleteProductCommand(id);
            var result = await _mediator.Send(command);

            if (!result.IsSuccess)
            {
                return NotFound(new { Message = result.Error });
            }

            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduct([FromBody] UpdateProductCommand command)
        {
            var result = await _mediator.Send(command);
            if (!result.IsSuccess)
            {
                return NotFound(new { Message = result.Error });
            }
            return NoContent();
        }

    }
}
