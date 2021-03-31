using Flx.Delivery.Application.Attributes;
using Flx.Delivery.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
