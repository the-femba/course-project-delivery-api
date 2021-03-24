using Flx.Delivery.Application.Attributes;
using MediatR;

namespace Flx.Delivery.Application.Microservices.Queries.GetCurrentUserInformationQuery
{
    [Auth]
    public class Query : IRequest<Result>
    {

    }
}
