using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public async Task<IActionResult> PostLoginUser([FromBody] Application.Microservices.Commands.CreateOrderCommand.Command command)
        {
            return Ok(await _mediator.Send(command));
        }
    }
}
