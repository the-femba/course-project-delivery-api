using Flx.Delivery.Application.Attributes;
using Flx.Delivery.Domain.Enums;
using MediatR;
using System;

namespace Flx.Delivery.Application.Microservices.Commands.PermitUserCommand
{
    [Auth(RoleType.Admin)]
    public sealed class Command : IRequest<Unit>
    {
        public Guid? UserId { get; set; }
        public string? UserEmail { get; set; }

        public RoleType Role { get; set; }
    }
}
