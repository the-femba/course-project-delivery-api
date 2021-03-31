using FluentValidation;
using Flx.Delivery.Application.Exceptions;
using Flx.Delivery.Application.Interfaces.Repositories;
using Flx.Delivery.Domain.Entities;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Flx.Delivery.Application.Microservices.Commands.PermitUserCommand
{
    public sealed class Handler : IRequestHandler<Command, Unit>
    {
        private readonly IUserEntityStorage _userStorage;

        public Handler(IUserEntityStorage userStorage)
        {
            _userStorage = userStorage;
        }

        public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
        {
            UserEntity? user = null;

            if (request.UserId is not null)
            {
                user = await _userStorage.Pick((Guid)request.UserId);
            }
            else if (request.UserEmail is not null)
            {
                user = await _userStorage.Pick(e => e.Email == request.UserEmail);
            }
            else
            {
                throw new ValidationException($"id and email from request is empty");
            }

            if (user is null)
            {
                throw new NotExistsDeliveryException($"user with id {request.UserId} or with email {request.UserEmail} not exists");
            }

            var userRoles = user!.Roles.ToList();

            if (!userRoles.Contains(request.Role))
            {
                userRoles.Add(request.Role);

                user.Roles = userRoles;

                await user.Push();
            }

            return new();
        }
    }
}
