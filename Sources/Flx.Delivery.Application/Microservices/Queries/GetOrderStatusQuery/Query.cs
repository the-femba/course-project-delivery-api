using MediatR;
using System;

namespace Flx.Delivery.Application.Microservices.Queries.GetOrderStatusQuery
{
    public sealed class Query : IRequest<Result>
    {
        public Guid OrderId { get; set; }
    }
}
