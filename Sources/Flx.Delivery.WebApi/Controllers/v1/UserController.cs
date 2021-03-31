using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Flx.Delivery.WebApi.Controllers.v1
{
    [ApiController]
    [Route("v1/user/")]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("info")]
        public async Task<IActionResult> GetRegistrateUser()
        {
            var query = new Application.Microservices.Queries.GetCurrentUserInformationQuery.Query();

            return Ok(await _mediator.Send(query));
        }

        [HttpPost("permitUser")]
        public async Task<IActionResult> GetPermitUser([FromBody] Application.Microservices.Commands.PermitUserCommand.Command command)
        {
            return Ok(await _mediator.Send(command));
        }
    }
}
