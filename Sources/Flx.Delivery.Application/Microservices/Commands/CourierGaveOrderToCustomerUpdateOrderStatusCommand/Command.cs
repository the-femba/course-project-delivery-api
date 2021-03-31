using Flx.Delivery.Application.Attributes;
using Flx.Delivery.Domain.Enums;
using MediatR;

namespace Flx.Delivery.Application.Microservices.Commands.CourierGaveOrderToCustomerUpdateOrderStatusCommand
{
    [Auth(RoleType.Courier)]
    public sealed class Command : IRequest<Unit>
    {

    }
}
