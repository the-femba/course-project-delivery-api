using Flx.Delivery.Application.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flx.Delivery.Application.Microservices.Queries.GetOrderInformationQuery
{
    [Auth]
    public sealed class Query
    {
        public Guid OrderId { get; set; }
    }
}
