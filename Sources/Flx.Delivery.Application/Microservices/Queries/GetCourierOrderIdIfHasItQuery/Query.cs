using Flx.Delivery.Application.Attributes;
using Flx.Delivery.Domain.Enums;
using MediatR;

namespace Flx.Delivery.Application.Microservices.Queries.GetCourierOrderIdIfHasItQuery
{
    [Auth(RoleType.Courier)]
    public sealed class Query : IRequest<Result>
    {

    }
}
