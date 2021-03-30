using System;

namespace Flx.Delivery.Application.Microservices.Commands.CreateOrderCommand
{
    public sealed class Result
    {
        public Guid CreatedOrderId { get; set; }
    }
}
