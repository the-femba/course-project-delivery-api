using MediatR;
using System;

namespace Flx.Delivery.Application.Microservices.Queries.GetRestaurantFoodsQuery
{
    public sealed class Query : IRequest<Result>
    {
        public Guid RestaurantId { get; set; }
    }
}
