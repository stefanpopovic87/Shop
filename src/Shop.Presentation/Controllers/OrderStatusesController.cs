using Mapster;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.Brands.Create;
using Shop.Application.Brands.Delete;
using Shop.Application.Brands.Get;
using Shop.Application.Brands.List;
using Shop.Application.Brands.Update;
using Shop.Application.OrderStatuses.Create;
using Shop.Application.OrderStatuses.Delete;
using Shop.Application.OrderStatuses.Get;
using Shop.Application.OrderStatuses.List;
using Shop.Application.OrderStatuses.Update;
using Shop.Common;
using Shop.Presentation.Controllers.Base;
using Swashbuckle.AspNetCore.Annotations;

namespace Shop.Presentation.Controllers
{
    [Route("api/orderstatuses")]
    public sealed class OrderStatusesController : BaseApiController
    {
        private readonly IMediator _mediator;

        public OrderStatusesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [SwaggerOperation(
            Summary = "Get all order statuses",
            Description = "Retrieves a list of all order statuses")]
        [Produces("application/json")]
        public async Task<IActionResult> GetOrderStatuses()
        {
            var query = new GetOrderStatusesQuery();

            var result = await _mediator.Send(query, CancellationToken);

            if (!result.IsSuccess)
            {
                return NotFound(new { Message = result });
            }

            return Ok(result);
        }

        [HttpGet("{id}")]
        [SwaggerOperation(
            Summary = "Get order status by ID",
            Description = "Retrieves a order status by its Id")]
        public async Task<IActionResult> GetOrderStatusById(int id)
        {
            var query = new GetOrderStatusByIdQuery(id);
            var result = await _mediator.Send(query, CancellationToken);

            if (!result.IsSuccess)
            {
                return NotFound(new { Message = result });
            }

            return Ok(result);
        }

        [HttpPost]
        [SwaggerOperation(
            Summary = "Create a new order status",
            Description = "Creates a new order status")]
        [ProducesResponseType(typeof(int), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ErrorResult), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateOrderStatus([FromBody] CreateOrderStatusRequest request)
        {
            var command = request.Adapt<CreateOrderStatusCommand>();
            var result = await _mediator.Send(command, CancellationToken);
            if (!result.IsSuccess)
            {
                return BadRequest(new { Message = result });
            }

            return CreatedAtAction(nameof(GetOrderStatusById), new { id = result.Value }, result.Value);
        }

        [HttpPut("{id}")]
        [SwaggerOperation(
            Summary = "Update a order status",
            Description = "Updates an existing order status")]
        public async Task<IActionResult> UpdateOrderStatus(int id, [FromBody] UpdateOrderStatusRequest request)
        {
            var command = request.Adapt<UpdateOrderStatusCommand>() with { Id = id };

            var result = await _mediator.Send(command, CancellationToken);

            if (!result.IsSuccess)
            {
                return BadRequest(new { Message = result });
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        [SwaggerOperation(
            Summary = "Delete a order status",
            Description = "Deletes an existing order status by its Id")]
        public async Task<IActionResult> DeleteOrderStatus(int id)
        {
            var command = new DeleteOrderStatusCommand(id);
            var result = await _mediator.Send(command, CancellationToken);

            if (!result.IsSuccess)
            {
                return NotFound(new { Message = result });
            }

            return NoContent();
        }
    }
}
