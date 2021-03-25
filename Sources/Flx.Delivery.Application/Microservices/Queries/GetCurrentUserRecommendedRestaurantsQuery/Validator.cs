using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flx.Delivery.Application.Microservices.Queries.GetCurrentUserRecommendedRestaurantsQuery
{
    public sealed class Validator : AbstractValidator<Query>
    {
        public Validator()
        {
            RuleFor(e => e.Count)
                .GreaterThan(0);

            RuleFor(e => e.Offset)
                .GreaterThanOrEqualTo(0);
        }
    }
}
