using Flx.Delivery.Application.Exceptions;
using Flx.Delivery.Application.Utils;
using Flx.Delivery.Domain.Entities;
using MediatR;
using Rovecode.Lotos.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace Flx.Delivery.Application.Microservices.Commands.LoginUserCommand
{
    public sealed class Handler : IRequestHandler<Command, Result>
    {
        private readonly IStorage<UserEntity> _userStorage;
        private readonly IStorage<AccessTokenEntity> _accessTokenStorage;

        public Handler(IStorage<UserEntity> userStorage, IStorage<AccessTokenEntity> accessTokenStorage)
        {
            _userStorage = userStorage;
            _accessTokenStorage = accessTokenStorage;
        }

        public async Task<Result> Handle(Command request, CancellationToken cancellationToken)
        {
            var hashPassword = StringUtil.GetHashString(request.Password);
            var exists = await _userStorage.Exists(e => e.Email == request.Email && e.PasswordHash == hashPassword);

            if (exists)
            {
                var user = await _userStorage.Pick(e => e.Email == request.Email);

                var token = new AccessTokenEntity()
                {
                    UserId = user!.Id,
                    Token = StringUtil.GenerateStringCrypt(),
                };

                await _accessTokenStorage.Put(token);

                return new()
                {
                    Token = token.Token,
                };
            }
            else
            {
                throw new NotExistsDeliveryException("user not exists");
            }
        }
    }
}
