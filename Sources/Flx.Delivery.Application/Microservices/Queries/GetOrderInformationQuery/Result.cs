using System;
using System.Collections.Generic;

namespace Flx.Delivery.Application.Microservices.Queries.GetOrderInformationQuery
{
    public sealed class Result
    {
        public Guid RestaurantId { get; set; }

        public IEnumerable<Guid> FoodsIds { get; set; } = null!;
    }
}
