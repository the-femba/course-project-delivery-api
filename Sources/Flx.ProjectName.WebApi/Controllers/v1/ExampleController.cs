using System;
using System.Threading.Tasks;
using Flx.ProjectName.Application.Fork.Commands;
using Flx.ProjectName.Application.Fork.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Flx.ProjectName.WebApi.Controllers.v1
{
    [ApiController]
    [Route("v1/[controller]")]
    public class ExampleController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ExampleController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("CreateExampleEntity")]
        public async Task<IActionResult> PostExampleEntity([FromBody] CreateExampleEntityCommand.Command command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpPost("AllExamplesEntitiesToOld")]
        public async Task<IActionResult> PostAllExamplesEntitiesToOld([FromBody] ChangeAllExampleEntitiesToOldCommand.Command command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllOldEntitiesQuery.Query();

            return Ok(await _mediator.Send(query));
        }
    }
}
