using System;

namespace Flx.Delivery.Application.Microservices.Queries.GetCourierOrderIdIfHasItQuery
{
    public sealed class Result
    {
        public Guid? OrderId { get; set; }
    }
}
