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

namespace Flx.Delivery.Application.Microservices.Commands.CourierCameToRestaurantUpdateOrderStatusCommand
{
    public sealed class Handler : IRequestHandler<Command, Unit>
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

        public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
        {
            string token = _authAccessor.AccessToken!;
            UserEntity courierUser = (await _userEntityStorage.PickViaAccessToken(token))!;

            var order = await _orderStorage.Pick(e => e.CourierId == courierUser.Id && e.Status == OrderStatus.СourierGoesToRestaurant);

            if (order == null)
            {
                throw new NotExistsDeliveryException($"сourier has no order or the order status does not match 'СourierGoesToRestaurant'");
            }

            order.Status = OrderStatus.СourierCameToRestaurant;
            await order.Push();

            return new();
        }

        private async Task ThrowIfOr(Guid restaurantId)
        {
            if (!await _restaurantStorage.Exists(restaurantId))
            {
                throw new NotExistsDeliveryException($"restaurant with id \'{restaurantId}\' is not exists");
            }
        }
    }
}
