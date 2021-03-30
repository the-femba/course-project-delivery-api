using System;
using System.Collections.Generic;

namespace Flx.Delivery.Application.Microservices.Queries.GetRestaurantFoodsQuery
{
    public sealed class Result
    {
        public IEnumerable<Guid> RestaurantFoodsIds { get; set; } = null!;
    }
}
