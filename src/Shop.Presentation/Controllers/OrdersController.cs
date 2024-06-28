using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.Order.Create;
using Shop.Application.Order.Delete;
using Shop.Application.Order.Get;
using Shop.Presentation.Controllers.Base;
using Swashbuckle.AspNetCore.Annotations;

namespace Shop.Presentation.Controllers
{
    public sealed class OrdersController : BaseApiController
    {
        private readonly IMediator _mediator;

        public OrdersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [SwaggerOperation(
            Summary = "Get order for user",
            Description = "Retrieves a order with items for current user")]
        public async Task<IActionResult> GetOrders()
        {
            var query = new GetOrderQuery();
            var result = await _mediator.Send(query, CancellationToken);

            if (!result.IsSuccess)
            {
                return NotFound(new { Message = result.Error });
            }

            return Ok(result);
        }

        [HttpPost]
        [SwaggerOperation(
            Summary = "Add item to order",
            Description = "Adding item to current order.")]
        public async Task<IActionResult> AddItemToOrder([FromBody] CreateOrderCommand command)
        {
            var result = await _mediator.Send(command, CancellationToken);
            if (!result.IsSuccess)
            {
                return BadRequest(new { Message = result.Error });
            }

            return CreatedAtAction(nameof(GetOrders), new { id = result.Value }, result.Value);
        }

        [HttpDelete]
        [SwaggerOperation(
            Summary = "Delete item from order",
            Description = "Deleting item from order list.")]
        public async Task<IActionResult> RemovetemToOrder([FromBody] DeleteOrderCommand command)
        {
            var result = await _mediator.Send(command, CancellationToken);
            if (!result.IsSuccess)
            {
                return NotFound(new { Message = result.Error });
            }

            return NoContent();
        }


    }
}
