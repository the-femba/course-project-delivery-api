using Flx.Delivery.Application.Attributes;
using Flx.Delivery.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flx.Delivery.Application.Microservices.Queries.GetCourierOrderIdIfHasItQuery
{
    [Auth(RoleType.Courier)]
    public sealed class Query : IRequest<Result>
    {

    }
}
