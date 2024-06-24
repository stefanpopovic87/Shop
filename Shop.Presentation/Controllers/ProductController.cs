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
            var product = await _mediator.Send(query);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var query = new GetByIdProductQuery(id);
            var product = await _mediator.Send(query);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductCommand command)
        {
            var id = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetProductById), new { id }, null);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProduct(DeleteProductCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduct(UpdateProductCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }

    }
}
