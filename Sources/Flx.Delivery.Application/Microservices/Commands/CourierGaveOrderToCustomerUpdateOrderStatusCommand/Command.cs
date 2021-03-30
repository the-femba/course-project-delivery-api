using Flx.Delivery.Application.Attributes;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flx.Delivery.Application.Microservices.Commands.CourierGaveOrderToCustomerUpdateOrderStatusCommand
{
    [Auth]
    public sealed class Command : IRequest<Unit>
    {

    }
}
