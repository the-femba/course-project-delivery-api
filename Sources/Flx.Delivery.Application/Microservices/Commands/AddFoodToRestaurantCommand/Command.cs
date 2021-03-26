using Flx.Delivery.Application.Attributes;
using Flx.Delivery.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
