using Flx.Delivery.Application.Attributes;
using MediatR;

namespace Flx.Delivery.Application.Microservices.Queries.GetCurrentUserRecommendedRestaurantsQuery
{
    [Auth]
    public sealed class Query : IRequest<Result>
    {
        public int Offset { get; set; }
        public int Count { get; set; }
    }
}
