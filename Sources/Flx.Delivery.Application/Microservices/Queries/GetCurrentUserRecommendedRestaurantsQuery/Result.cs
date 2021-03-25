using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flx.Delivery.Application.Microservices.Queries.GetCurrentUserRecommendedRestaurantsQuery
{
    public sealed class Result
    {
        public IEnumerable<Guid> RecommendedRestaurantsIds { get; set; } = null!;
    }
}
