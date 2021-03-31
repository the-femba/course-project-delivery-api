using System;

namespace Flx.Delivery.Application.Microservices.Queries.GetUserOrderIdIfHasItQuery
{
    public sealed class Result
    {
        public Guid? OrderId { get; set; }
    }
}
