using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flx.Delivery.Application.Microservices.Commands.CreateRestaurantCommand
{
    public sealed class Validator : AbstractValidator<Command>
    {
        public Validator()
        {
            RuleFor(e => e.RestaurantPhotos)
                .NotNull();

            RuleFor(e => e.RestaurantInformation)
                .NotNull();

            RuleFor(e => e.RestaurantPhotos.BackwardPhotoBase64)
                .NotNull()
                .Matches(@"^[a-zA-Z0-9\+/]*={0,2}$");

            RuleFor(e => e.RestaurantPhotos.LogoPhotoBase64)
                .NotNull()
                .Matches(@"^[a-zA-Z0-9\+/]*={0,2}$");

            RuleFor(e => e.RestaurantInformation.Name)
                .NotNull()
                .MinimumLength(1)
                .MaximumLength(16)
                .Matches("^[A-zёЁА-я]");

            RuleFor(e => e.RestaurantInformation.Description)
                .NotNull()
                .MinimumLength(1)
                .MaximumLength(32)
                .Matches("^[A-zёЁА-я]");
        }
    }
}
