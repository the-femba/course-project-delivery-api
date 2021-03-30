using Flx.Delivery.Application.Exceptions;
using Flx.Delivery.Application.Interfaces.Repositories;
using Flx.Delivery.Domain.Entities;
using MediatR;
using Rovecode.Lotos.Repositories;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Flx.Delivery.Application.Microservices.Queries.GetFoodInformationQuery
{
    public sealed class Handler : IRequestHandler<Query, Result>
    {
        private readonly IStorage<RestaurantEntity> _restaurantStorage;
        private readonly IStorage<FoodEntity> _foodStorage;
        private readonly IFileStorage _fileStorage;

        public Handler(IStorage<RestaurantEntity> restaurantStorage, IStorage<FoodEntity> foodStorage, IFileStorage fileStorage)
        {
            _restaurantStorage = restaurantStorage;
            _fileStorage = fileStorage;
            _foodStorage = foodStorage;
        }

        public async Task<Result> Handle(Query request, CancellationToken cancellationToken)
        {
            await ThrowIfFoodIdNotExists(request.FoodId);

            var foodEntity = (await _foodStorage.Pick(request.FoodId))!;

            var foodPhotoData = _fileStorage.GetBase64String("foods_images", foodEntity.FoodPhotoName)!;

            return new()
            {
                FoodPhotoBase64 = foodPhotoData,
                Name = foodEntity.Name,
                PriceGrn = foodEntity.PriceGrn,
            };
        }

        private async Task ThrowIfFoodIdNotExists(Guid restaurantId)
        {
            if (!await _foodStorage.Exists(restaurantId))
            {
                throw new NotExistsDeliveryException($"food is not exists with id {restaurantId}");
            }
        }
    }
}
