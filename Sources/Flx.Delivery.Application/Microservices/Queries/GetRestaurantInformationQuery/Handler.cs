using Flx.Delivery.Application.Exceptions;
using Flx.Delivery.Application.Interfaces.Repositories;
using Flx.Delivery.Domain.Entities;
using MediatR;
using Rovecode.Lotos.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Flx.Delivery.Application.Microservices.Queries.GetRestaurantInformationQuery
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
            await ThrowIfRestaurantIsNotExistsViaId(request.RestaurantId)!;

            var restaurant = (await _restaurantStorage.Pick(request.RestaurantId))!;

            var backwardPhotoData = _fileStorage.GetBase64String("restaurants_images", restaurant.Photos.BackwardPhotoName)!;
            var logoPhotoData = _fileStorage.GetBase64String("restaurants_images", restaurant.Photos.LogoPhotoName)!;

            return new()
            {
                Information = restaurant.Information,
                PhotosData = new()
                {
                    BackwardPhotoBase64 = backwardPhotoData,
                    LogoPhotoBase64 = logoPhotoData,
                }
            };
        }

        private async Task ThrowIfRestaurantIsNotExistsViaId(Guid restaurantId)
        {
            if (!await _restaurantStorage.Exists(restaurantId))
            {
                throw new NotExistsDeliveryException($"restaurant with id \'{restaurantId}\' not exists");
            }
        }
    }
}
