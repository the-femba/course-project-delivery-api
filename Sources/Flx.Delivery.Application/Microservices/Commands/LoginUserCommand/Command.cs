using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flx.Delivery.Application.Microservices.Commands.LoginUserCommand
{
    public sealed class Command : IRequest<Result>
    {
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}
