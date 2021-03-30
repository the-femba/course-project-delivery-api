using Flx.Delivery.Application.Attributes;
using Flx.Delivery.Domain.Enums;
using MediatR;
using System;

namespace Flx.Delivery.Application.Microservices.Commands.AddFoodToRestaurantCommand
{
    [Auth(RoleType.Admin)]
    public sealed class Command : IRequest<Unit>
    {
        public Guid RestaurantId { get; set; }

        public string FoodPhotoBase64 { get; set; } = null!;

        public string Name { get; set; } = null!;

        public double PriceGrn { get; set; }
    }
}
