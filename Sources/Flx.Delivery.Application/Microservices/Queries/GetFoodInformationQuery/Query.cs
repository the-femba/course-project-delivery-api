using MediatR;
using System;

namespace Flx.Delivery.Application.Microservices.Queries.GetFoodInformationQuery
{
    public sealed class Query : IRequest<Result>
    {
        public Guid FoodId { get; set; }
    }
}
