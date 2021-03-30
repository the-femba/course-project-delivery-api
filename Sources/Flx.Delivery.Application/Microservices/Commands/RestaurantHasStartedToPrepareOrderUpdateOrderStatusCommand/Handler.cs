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

namespace Flx.Delivery.Application.Microservices.Commands.RestaurantHasStartedToPrepareOrderUpdateOrderStatusCommand
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
            var order = await _orderStorage.Pick(e => e.Id == request.OrderId && e.Status == OrderStatus.СourierCameToRestaurant);

            if (order is null)
            {
                throw new NotExistsDeliveryException($"order not exists or the order status does not match 'СourierCameToRestaurant'");
            }

            order.Status = OrderStatus.RestaurantPreparesFood;
            await order.Push();

            return new();
        }
    }
}
