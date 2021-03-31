using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Flx.Delivery.WebApi.Controllers.v1
{
    [ApiController]
    [Route("v1/order/")]
    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("createOrder")]
        public async Task<IActionResult> PostCreateOrder([FromBody] Application.Microservices.Commands.CreateOrderCommand.Command command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpPost("updateOrderStatusToCourierGoesToCustomer")]
        public async Task<IActionResult> PostCourierGoesToCustomerUpdateOrderStatusCommand()
        {
            var command = new Application.Microservices.Commands.CourierGoesToCustomerUpdateOrderStatusCommand.Command();

            return Ok(await _mediator.Send(command));
        }

        [HttpPost("updateOrderStatusToCourierCameToRestaurant")]
        public async Task<IActionResult> PostCourierCameToRestaurantUpdateOrderStatusCommand()
        {
            var command = new Application.Microservices.Commands.CourierCameToRestaurantUpdateOrderStatusCommand.Command();

            return Ok(await _mediator.Send(command));
        }

        [HttpPost("updateOrderStatusToCourierGaveOrderToCustomer")]
        public async Task<IActionResult> PostCourierGaveOrderToCustomerUpdateOrderStatusCommand()
        {
            var command = new Application.Microservices.Commands.CourierGaveOrderToCustomerUpdateOrderStatusCommand.Command();

            return Ok(await _mediator.Send(command));
        }

        [HttpPost("updateOrderStatusToRestaurantHasStartedToPrepareOrder")]
        public async Task<IActionResult> PostRestaurantHasStartedToPrepareOrderUpdateOrderStatusCommand([FromQuery] Guid orderId)
        {
            var command = new Application.Microservices.Commands.RestaurantHasStartedToPrepareOrderUpdateOrderStatusCommand.Command()
            {
                OrderId = orderId,
            };

            return Ok(await _mediator.Send(command));
        }

        [HttpPost("updateOrderStatusToRestaurantPreperedOrder")]
        public async Task<IActionResult> PostRestaurantPreperedOrderUpdateOrderStatusCommand([FromQuery] Guid orderId)
        {
            var command = new Application.Microservices.Commands.RestaurantPreperedOrderUpdateOrderStatusCommand.Command()
            {
                OrderId = orderId,
            };

            return Ok(await _mediator.Send(command));
        }

        [HttpGet("getCourierOrderIdIfHasIt")]
        public async Task<IActionResult> GetCourierOrderIdIfHasItQuery()
        {
            var query = new Application.Microservices.Queries.GetCourierOrderIdIfHasItQuery.Query();

            return Ok(await _mediator.Send(query));
        }

        [HttpGet("getUserOrderIdIfHasItQuery")]
        public async Task<IActionResult> GetUserOrderIdIfHasItQuery()
        {
            var query = new Application.Microservices.Queries.GetUserOrderIdIfHasItQuery.Query();

            return Ok(await _mediator.Send(query));
        }

        [HttpGet("getOrderInformation")]
        public async Task<IActionResult> GetOrderInformationQuery([FromQuery] Guid orderId)
        {
            var query = new Application.Microservices.Queries.GetOrderInformationQuery.Query()
            {
                OrderId = orderId,
            };

            return Ok(await _mediator.Send(query));
        }

        [HttpGet("getOrderStatusQuery")]
        public async Task<IActionResult> GetOrderStatusQuery([FromQuery] Guid orderId)
        {
            var query = new Application.Microservices.Queries.GetOrderStatusQuery.Query()
            {
                OrderId = orderId,
            };

            return Ok(await _mediator.Send(query));
        }
    }
}
