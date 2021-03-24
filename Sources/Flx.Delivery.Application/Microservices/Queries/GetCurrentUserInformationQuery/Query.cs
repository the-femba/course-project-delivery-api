using Flx.Delivery.Application.Attributes;
using Flx.Delivery.Application.Enums;
using Flx.Delivery.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flx.Delivery.Application.Microservices.Queries.GetCurrentUserInformationQuery
{
    [Auth(RoleType.User, RoleType.Admin, CheckStrategy = RoleCheckStrategy.OneMatch)]
    public class Query : IRequest<Result>
    {

    }
}
