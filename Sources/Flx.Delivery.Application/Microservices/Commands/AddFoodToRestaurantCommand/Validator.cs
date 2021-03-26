using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flx.Delivery.Application.Microservices.Commands.AddFoodToRestaurantCommand
{
    public sealed class Validator : AbstractValidator<Command>
    {
        public Validator()
        {
            RuleFor(e => e.FoodPhotoBase64)
                .NotNull()
                .Matches(@"^[a-zA-Z0-9\+/]*={0,2}$");

            RuleFor(e => e.Name)
                .NotNull()
                .MinimumLength(1)
                .MaximumLength(32)
                .Matches("^[A-zёЁА-я]");

            RuleFor(e => e.PriceGrn)
                .NotNull()
                .GreaterThan(0)
                .LessThanOrEqualTo(1000);
        }
    }
}
