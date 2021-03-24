using MediatR;

namespace Flx.Delivery.Application.Microservices.Commands.LoginUserCommand
{
    public sealed class Command : IRequest<Result>
    {
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}
