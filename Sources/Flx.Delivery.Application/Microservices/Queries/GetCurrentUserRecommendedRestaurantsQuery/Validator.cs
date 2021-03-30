using FluentValidation;

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
