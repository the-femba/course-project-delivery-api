using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Flx.Delivery.WebApi.Controllers.v1
{
    [ApiController]
    [Route("v1/restaurant/")]
    public class RestaurantController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RestaurantController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("createRestaurant")]
        public async Task<IActionResult> PostCreateRestaurant([FromBody] Application.Microservices.Commands.CreateRestaurantCommand.Command command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpPost("addFoodToRestaurant")]
        public async Task<IActionResult> PostAddFoodToRestaurant([FromBody] Application.Microservices.Commands.AddFoodToRestaurantCommand.Command command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpGet("getRecomendedForUser")]
        public async Task<IActionResult> PostGetRecomendedRestaurant([FromQuery] int count, [FromQuery] int offset)
        {
            var query = new Application.Microservices.Queries.GetCurrentUserRecommendedRestaurantsQuery.Query
            {
                Count = count,
                Offset = offset,
            };

            return Ok(await _mediator.Send(query));
        }

        [HttpGet("getInformation")]
        public async Task<IActionResult> PostGetRecomendedRestaurant([FromQuery] Guid id)
        {
            var query = new Application.Microservices.Queries.GetRestaurantInformationQuery.Query
            {
                RestaurantId = id,
            };

            return Ok(await _mediator.Send(query));
        }

        [HttpGet("getRestaurantsFoods")]
        public async Task<IActionResult> GetRestaurantsFoods([FromQuery] Guid id)
        {
            var query = new Application.Microservices.Queries.GetRestaurantFoodsQuery.Query
            {
                RestaurantId = id,
            };

            return Ok(await _mediator.Send(query));
        }

        [HttpGet("getFoodInformation")]
        public async Task<IActionResult> GetFoodInformation([FromQuery] Guid id)
        {
            var query = new Application.Microservices.Queries.GetFoodInformationQuery.Query
            {
                FoodId = id,
            };

            return Ok(await _mediator.Send(query));
        }
    }
}
