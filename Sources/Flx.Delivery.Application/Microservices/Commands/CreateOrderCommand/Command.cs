using Flx.Delivery.Application.Attributes;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flx.Delivery.Application.Microservices.Commands.CreateOrderCommand
{
    [Auth]
    public sealed class Command : IRequest<Result>
    {
        public Guid RestaurantId { get; set; }
        public IEnumerable<Guid> FoodsIds { get; set; } = null!;
    }
}
