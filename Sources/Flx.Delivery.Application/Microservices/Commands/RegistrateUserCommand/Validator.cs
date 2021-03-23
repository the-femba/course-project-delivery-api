using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flx.Delivery.Application.Microservices.Commands.RegistrateUserCommand
{
    public sealed class Validator : AbstractValidator<Command>
    {
        public Validator()
        {
            RuleFor(e => e.FirstName)
                .NotNull()
                .MinimumLength(1)
                .MaximumLength(18)
                .Matches("^[a-zёа-я]");

            RuleFor(e => e.LastName)
                .NotNull()
                .MinimumLength(1)
                .MaximumLength(18)
                .Matches("^[a-zёа-я]");

            RuleFor(e => e.Email)
                .NotNull()
                .EmailAddress();

            RuleFor(e => e.Password)
                .NotNull()
                .MinimumLength(8)
                .MaximumLength(256)
                .Matches("[A-z]")
                .Matches("[0-9]");
        }
    }
}
