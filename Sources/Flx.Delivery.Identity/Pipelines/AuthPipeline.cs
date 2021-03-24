using Flx.Delivery.Application.Attributes;
using Flx.Delivery.Application.Enums;
using Flx.Delivery.Application.Exceptions;
using Flx.Delivery.Application.Interfaces.Accessors;
using Flx.Delivery.Application.Interfaces.Repositories;
using Flx.Delivery.Domain.Entities;
using Flx.Delivery.Domain.Enums;
using MediatR;
using Rovecode.Lotos.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Flx.Delivery.Identity.Pipelines
{
    public sealed class AuthPipeline<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly IHttpAuthAccessor _authAccessor;
        private readonly IStorage<AccessTokenEntity> _accessTokenStorage;
        private readonly IUserEntityStorage _userStorage;

        public AuthPipeline(IHttpAuthAccessor authAccessor, IStorage<AccessTokenEntity> accessTokenStorage, IUserEntityStorage userStorage)
        {
            _authAccessor = authAccessor;
            _accessTokenStorage = accessTokenStorage;
            _userStorage = userStorage;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var attribute = request.GetType().GetCustomAttributes(typeof(AuthAttribute), false).FirstOrDefault();

            if (attribute is not null)
            {
                await ThrowIfTokenNotExistsOrNull(_authAccessor.AccessToken);

                AuthAttribute authAttribute = (attribute as AuthAttribute)!;

                if (authAttribute.Roles?.Count() > 0)
                {
                    if (!await CheckRolesWithStrategy(_authAccessor.AccessToken!, authAttribute.Roles!, authAttribute.CheckStrategy))
                    {
                        throw new AuthDeliveryException();
                    }
                    else
                    {
                        return await next();
                    }
                }
                else
                {
                    return await next();
                }
            }
            else
            {
                return await next();
            }
        }

        public async Task ThrowIfTokenNotExistsOrNull(string? token)
        {
            if (token is null || !await _accessTokenStorage.Exists(e => e.Token == token))
            {
                throw new AuthDeliveryException();
            }
        }

        public Task<bool> CheckRolesWithStrategy(string token, IEnumerable<RoleType> roles, RoleCheckStrategy checkStrategy)
        {
            switch (checkStrategy)
            {
                case RoleCheckStrategy.AllMatch:
                    return UserHasAllRoles(token, roles);
                case RoleCheckStrategy.OneMatch:
                    return UserHasOneRoles(token, roles);
                default:
                    // TODO: Add moddern ex
                    throw new NotImplementedException();
            }
        }

        public async Task<bool> UserHasAllRoles(string token, IEnumerable<RoleType> roles)
        {
            var user = (await _userStorage.PickViaAccessToken(token))!;

            foreach (RoleType item in roles)
            {
                if (!user.IsHasRole(item))
                {
                    return false;
                }
            }

            return true;
        }

        public async Task<bool> UserHasOneRoles(string token, IEnumerable<RoleType> roles)
        {
            var user = (await _userStorage.PickViaAccessToken(token))!;

            foreach (RoleType item in roles)
            {
                if (user.IsHasRole(item))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
