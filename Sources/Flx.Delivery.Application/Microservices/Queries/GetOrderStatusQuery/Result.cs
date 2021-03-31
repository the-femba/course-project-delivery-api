using Flx.Delivery.Domain.Enums;

namespace Flx.Delivery.Application.Microservices.Queries.GetOrderStatusQuery
{
    public sealed class Result
    {
        public OrderStatus OrderStatus { get; set; }
    }
}
