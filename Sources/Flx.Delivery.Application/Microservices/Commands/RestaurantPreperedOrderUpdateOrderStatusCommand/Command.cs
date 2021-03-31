using Flx.Delivery.Application.Attributes;
using Flx.Delivery.Domain.Enums;
using MediatR;
using System;

namespace Flx.Delivery.Application.Microservices.Commands.RestaurantPreperedOrderUpdateOrderStatusCommand
{
    [Auth(RoleType.Admin)]
    public sealed class Command : IRequest<Unit>
    {
        public Guid OrderId { get; set; }
    }
}
