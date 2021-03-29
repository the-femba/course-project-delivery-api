using Flx.Delivery.Application.Exceptions;
using Flx.Delivery.Application.Interfaces.Accessors;
using Flx.Delivery.Application.Interfaces.Repositories;
using Flx.Delivery.Domain.Entities;
using Flx.Delivery.Domain.Enums;
using MediatR;
using Rovecode.Lotos.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Flx.Delivery.Application.Microservices.Commands.CreateOrderCommand
{
    public sealed class Handler : IRequestHandler<Command, Result>
    {
        private readonly IStorage<OrderEntity> _orderStorage;
        private readonly IStorage<RestaurantEntity> _restaurantStorage;
        private readonly IUserEntityStorage _userEntityStorage;
        private readonly IHttpAuthAccessor _authAccessor;

        public Handler(IHttpAuthAccessor authAccessor, IUserEntityStorage userEntityStorage, IStorage<OrderEntity> orderStorage, IStorage<RestaurantEntity> restaurantStorage)
        {
            _userEntityStorage = userEntityStorage;
            _orderStorage = orderStorage;
            _userEntityStorage = userEntityStorage;
            _restaurantStorage = restaurantStorage;
            _authAccessor = authAccessor;
        }

        public async Task<Result> Handle(Command request, CancellationToken cancellationToken)
        {
            await ThrowIfRestaurantNotExistsById(request.RestaurantId);
            await ThrowIfFoodsIdsIsNotFromSelectedRestaurant(request.RestaurantId, request.FoodsIds);

            string token = _authAccessor.AccessToken!;
            UserEntity user = (await _userEntityStorage.PickViaAccessToken(token))!;

            var order = await _orderStorage.Put(new()
            {
                CustomerId = user.Id,
                RestaurantId = request.RestaurantId,
                CreateDate = DateTime.Now,
                OrderFoodsIds = request.FoodsIds,
                Status = OrderStatus.SearchForCourier,
            });

            return new()
            {
                CreatedOrderId = order.Id,
            };
        }

        private async Task ThrowIfRestaurantNotExistsById(Guid restaurantId)
        {
            if (!await _restaurantStorage.Exists(restaurantId))
            {
                throw new NotExistsDeliveryException($"restaurant with id \'{restaurantId}\' is not exists");
            }
        }

        private async Task ThrowIfFoodsIdsIsNotFromSelectedRestaurant(Guid restaurantId, IEnumerable<Guid> foodsIds)
        {
            var restaurant = (await _restaurantStorage.Pick(restaurantId))!;

            foreach (var item in foodsIds)
            {
                if (!restaurant.FoodsIds.Contains(item))
                {
                    throw new NotExistsDeliveryException($"food with id \'{item}\' is dnot from restaurant with id \'{restaurantId}\'");
                }
            }
        }
    }
}
