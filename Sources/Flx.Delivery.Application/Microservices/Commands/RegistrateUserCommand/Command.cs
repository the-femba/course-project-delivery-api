using MediatR;

namespace Flx.Delivery.Application.Microservices.Commands.RegistrateUserCommand
{
    public sealed class Command : IRequest<Unit>
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string Password { get; set; } = null!;
    }
}
