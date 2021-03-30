using Flx.Delivery.Application.Exceptions;
using Flx.Delivery.Application.Interfaces.Repositories;
using Flx.Delivery.Domain.Entities;
using MediatR;
using Rovecode.Lotos.Repositories;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Flx.Delivery.Application.Microservices.Queries.GetRestaurantFoodsQuery
{
    public sealed class Handler : IRequestHandler<Query, Result>
    {
        private readonly IStorage<RestaurantEntity> _restaurantStorage;
        private readonly IFileStorage _fileStorage;

        public Handler(IStorage<RestaurantEntity> restaurantStorage, IFileStorage fileStorage)
        {
            _restaurantStorage = restaurantStorage;
            _fileStorage = fileStorage;
        }

        public async Task<Result> Handle(Query request, CancellationToken cancellationToken)
        {
            await ThrowIfRestaurantIdNotExists(request.RestaurantId);

            var restaurant = (await _restaurantStorage.Pick(request.RestaurantId))!;

            return new()
            {
                RestaurantFoodsIds = restaurant.FoodsIds,
            };
        }

        private async Task ThrowIfRestaurantIdNotExists(Guid restaurantId)
        {
            if (!await _restaurantStorage.Exists(restaurantId))
            {
                throw new NotExistsDeliveryException($"organization is not exists with id {restaurantId}");
            }
        }
    }
}
