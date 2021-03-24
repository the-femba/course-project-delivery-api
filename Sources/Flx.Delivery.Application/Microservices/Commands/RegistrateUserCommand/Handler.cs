using AutoMapper;
using Flx.Delivery.Application.Exceptions;
using Flx.Delivery.Application.Utils;
using Flx.Delivery.Domain.Entities;
using MediatR;
using Rovecode.Lotos.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace Flx.Delivery.Application.Microservices.Commands.RegistrateUserCommand
{
    public sealed class Handler : IRequestHandler<Command, Unit>
    {
        private readonly IStorage<UserEntity> _userStorage;
        private readonly IMapper _mapper;

        public Handler(IMapper mapper, IStorage<UserEntity> userStorage)
        {
            _userStorage = userStorage;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
        {
            var exists = await _userStorage.Exists(e => e.Email == request.Email);

            if (!exists)
            {
                var userEntity = _mapper.Map<UserEntity>(request);

                userEntity.PasswordHash = StringUtil.GetHashString(userEntity.PasswordHash);

                await _userStorage.Put(userEntity);

                return new Unit();
            }
            else
            {
                throw new ExistsDeliveryException("user already exists");
            }
        }
    }
}
