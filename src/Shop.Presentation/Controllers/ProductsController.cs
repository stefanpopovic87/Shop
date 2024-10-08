﻿using Mapster;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.Categories.Update;
using Shop.Application.Products.Create;
using Shop.Application.Products.Delete;
using Shop.Application.Products.Get;
using Shop.Application.Products.List;
using Shop.Application.Products.Update;
using Shop.Presentation.Controllers.Base;
using Swashbuckle.AspNetCore.Annotations;

namespace Shop.Presentation.Controllers
{
    public sealed class ProductsController : BaseApiController
    {
        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [SwaggerOperation(
            Summary = "Get all products", 
            Description = "Retrieves a list of all products.")]
        public async Task<IActionResult> GetProducts()
        {
            var query = new GetProductsQuery();

            var result = await _mediator.Send(query, CancellationToken);

            if (!result.IsSuccess)
            {
                return NotFound(new { Message = result });
            }

            return Ok(result);
        }

        [HttpGet("{id}")]
        [SwaggerOperation(
            Summary = "Get product by ID", 
            Description = "Retrieves a product by its ID.")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var query = new GetProductByIdQuery(id);
            var result = await _mediator.Send(query, CancellationToken);

            if (!result.IsSuccess)
            {
                return NotFound(new { Message = result });
            }

            return Ok(result);
        }

        [HttpPost]
        [SwaggerOperation(
            Summary = "Create a new product", 
            Description = "Creates a new product.")]
        public async Task<IActionResult> CreateProduct([FromBody] CreateProductCommand command)
        {
            var result = await _mediator.Send(command, CancellationToken);
            if (!result.IsSuccess)
            {
                return BadRequest(new { Message = result });
            }

            return CreatedAtAction(nameof(GetProductById), new { id = result.Value }, result.Value);
        }

        [HttpPut("{id}")]
        [SwaggerOperation(
            Summary = "Update a product", 
            Description = "Updates an existing product.")]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody] UpdateProductRequest request)
        {
            var command = request.Adapt<UpdateProductCommand>() with { Id = id };
            var result = await _mediator.Send(command, CancellationToken);

            if (!result.IsSuccess)
            {
                return BadRequest(new { Message = result });
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        [SwaggerOperation(
            Summary = "Delete a product", 
            Description = "Deletes an existing product by its ID.")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var command = new DeleteProductCommand(id);
            var result = await _mediator.Send(command, CancellationToken);

            if (!result.IsSuccess)
            {
                return NotFound(new { Message = result });
            }

            return NoContent();
        }

    }
}
