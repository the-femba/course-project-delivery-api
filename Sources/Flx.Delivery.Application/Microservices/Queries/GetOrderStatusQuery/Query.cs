using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flx.Delivery.Application.Microservices.Queries.GetOrderStatusQuery
{
    public sealed class Query : IRequest<Result>
    {
        public Guid OrderId { get; set; }
    }
}
