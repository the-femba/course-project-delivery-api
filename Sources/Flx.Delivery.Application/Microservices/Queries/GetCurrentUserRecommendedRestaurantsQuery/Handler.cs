using Flx.Delivery.Domain.Entities;
using MediatR;
using Rovecode.Lotos.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Flx.Delivery.Application.Microservices.Queries.GetCurrentUserRecommendedRestaurantsQuery
{
    public sealed class Handler : IRequestHandler<Query, Result>
    {
        private readonly IStorage<RestaurantEntity> _restaurantStorage;

        public Handler(IStorage<RestaurantEntity> restaurantStorage)
        {
            _restaurantStorage = restaurantStorage;
        }

        public async Task<Result> Handle(Query request, CancellationToken cancellationToken)
        {
            // TODO: Optimize for nrml offset and count in future at lotos lib
            var restaurants = (await _restaurantStorage.PickMany()).ToList();

            int maxFantasyIndex = request.Offset + Math.Clamp(request.Count - 1, 0, int.MaxValue);
            int maxLifeIndex = restaurants.Count - 1;

            if (request.Offset > maxLifeIndex)
            {
                restaurants = new List<RestaurantEntity>();
            }
            else
            {
                var delta = Math.Clamp(maxFantasyIndex - maxLifeIndex, 0, int.MaxValue);
                restaurants = restaurants.GetRange(request.Offset, request.Count - delta);
            }

            var restaurantsIds = restaurants.Select(e => e.Id);

            return new()
            {
                RecommendedRestaurantsIds = restaurantsIds,
            };
        }
    }
}
