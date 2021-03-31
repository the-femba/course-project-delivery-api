using Flx.Delivery.Application.Attributes;
using MediatR;
using System;

namespace Flx.Delivery.Application.Microservices.Queries.GetOrderInformationQuery
{
    [Auth]
    public sealed class Query : IRequest<Result>
    {
        public Guid OrderId { get; set; }
    }
}
