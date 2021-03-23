using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flx.Delivery.Application.Microservices.Commands.LoginUserCommand
{
    public sealed class Result
    {
        public string Token { get; set; } = null!;
    }
}
