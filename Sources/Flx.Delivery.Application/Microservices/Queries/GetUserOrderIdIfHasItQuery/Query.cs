using Flx.Delivery.Application.Attributes;
using Flx.Delivery.Domain.Enums;
using MediatR;

namespace Flx.Delivery.Application.Microservices.Queries.GetUserOrderIdIfHasItQuery
{
    [Auth(RoleType.User)]
    public sealed class Query : IRequest<Result>
    {

    }
}
