using AutoMapper;
using Flx.Delivery.Application.Exceptions;
using Flx.Delivery.Application.Interfaces.Repositories;
using Flx.Delivery.Application.Models;
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

namespace Flx.Delivery.Application.Microservices.Commands.CreateRestaurantCommand
{
    public sealed class Handler : IRequestHandler<Command, Result>
    {
        private readonly IStorage<RestaurantEntity> _restaurantStorage;
        private readonly IFileStorage _fileStorage;
        private readonly IMapper _mapper;

        public Handler(IMapper mapper, IStorage<RestaurantEntity> restaurantStorage, IFileStorage fileStorage)
        {
            _restaurantStorage = restaurantStorage;
            _fileStorage = fileStorage;
            _mapper = mapper;
        }

        public async Task<Result> Handle(Command request, CancellationToken cancellationToken)
        {
            await ThrowIfRestaurantExistsWithSameName(request.RestaurantInformation.Name);

            var restaurant = new RestaurantEntity
            {
                Information = request.RestaurantInformation,
            };

            await _restaurantStorage.Put(restaurant);

            var backwardPhotoName = BuildPhotoName(restaurant.Id, "backward");
            var logoPhotoName = BuildPhotoName(restaurant.Id, "logo");

            _fileStorage.PutBase64String("restaurants_images", backwardPhotoName, request.RestaurantPhotos.BackwardPhotoBase64);
            _fileStorage.PutBase64String("restaurants_images", logoPhotoName, request.RestaurantPhotos.LogoPhotoBase64);

            restaurant.Photos = new()
            {
                BackwardPhotoName = backwardPhotoName,
                LogoPhotoName = logoPhotoName,
            };

            await restaurant.Push();

            return new()
            {
                RestaurantId = restaurant.Id,
            };
        }

        public string BuildPhotoName(Guid restaurantId, string prefix)
        {
            return $"{prefix}-{restaurantId}-{StringUtil.GenerateString(length: 6)}.flximg";
        }

        private async Task ThrowIfRestaurantExistsWithSameName(string name)
        {
            if (await _restaurantStorage.Exists(e => e.Information.Name == name))
            {
                throw new ExistsDeliveryException($"restaurant with name \'{name}\' already exists");
            }
        }
    }
}
