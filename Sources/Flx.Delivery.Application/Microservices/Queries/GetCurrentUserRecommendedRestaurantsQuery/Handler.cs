using Flx.Delivery.Domain.Entities;
using MediatR;
using Rovecode.Lotos.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            restaurants = restaurants.GetRange(request.Offset, request.Count);

            var restaurantsIds = restaurants.Select(e => e.Id);

            return new()
            {
                RecommendedRestaurantsIds = restaurantsIds,
            };
        }
    }
}
