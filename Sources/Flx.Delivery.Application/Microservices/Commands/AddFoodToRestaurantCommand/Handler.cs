using AutoMapper;
using Flx.Delivery.Application.Exceptions;
using Flx.Delivery.Application.Interfaces.Repositories;
using Flx.Delivery.Application.Utils;
using Flx.Delivery.Domain.Entities;
using MediatR;
using Rovecode.Lotos.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Flx.Delivery.Application.Microservices.Commands.AddFoodToRestaurantCommand
{
    public sealed class Handler : IRequestHandler<Command, Unit>
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

        public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
        {
            await ThrowIfRestaurantIdNotExists(request.RestaurantId);

            var foodEntity = new FoodEntity
            {
                Name = request.Name,
                PriceGrn = request.PriceGrn,
            };

            await _foodStorage.Put(foodEntity);

            var foodImageName = BuildPhotoName(foodEntity.Id);

            foodEntity.FoodPhotoName = foodImageName;
            await foodEntity.Push();

            _fileStorage.PutBase64String("foods_images", foodImageName, request.FoodPhotoBase64);

            var restaurantEntity = (await _restaurantStorage.Pick(request.RestaurantId))!;

            var foodsIdsList = restaurantEntity.FoodsIds.ToList();
            foodsIdsList.Add(foodEntity.Id);

            restaurantEntity.FoodsIds = foodsIdsList;

            await restaurantEntity.Push();

            return new();
        }

        private string BuildPhotoName(Guid foodId)
        {
            return $"food_photo-{foodId}-{StringUtil.GenerateString(length: 6)}.flximg";
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
