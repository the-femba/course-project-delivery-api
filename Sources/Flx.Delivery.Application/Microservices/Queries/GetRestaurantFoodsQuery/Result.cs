using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flx.Delivery.Application.Microservices.Queries.GetRestaurantFoodsQuery
{
    public sealed class Result
    {
        public IEnumerable<Guid> RestaurantFoodsIds { get; set; } = null!;
    }
}
