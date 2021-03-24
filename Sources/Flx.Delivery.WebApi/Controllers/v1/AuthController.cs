using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Flx.Delivery.WebApi.Controllers.v1
{
    [ApiController]
    [Route("v1/auth/")]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("singIn")]
        public async Task<IActionResult> PostRegistrateUser([FromBody] Application.Microservices.Commands.RegistrateUserCommand.Command command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpPost("singUp")]
        public async Task<IActionResult> PostLoginUser([FromBody] Application.Microservices.Commands.LoginUserCommand.Command command)
        {
            return Ok(await _mediator.Send(command));
        }
    }
}
