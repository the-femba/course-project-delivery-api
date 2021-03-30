using System;
using System.Collections.Generic;

namespace Flx.Delivery.Application.Microservices.Queries.GetCurrentUserRecommendedRestaurantsQuery
{
    public sealed class Result
    {
        public IEnumerable<Guid> RecommendedRestaurantsIds { get; set; } = null!;
    }
}
