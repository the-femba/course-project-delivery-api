using Flx.Delivery.Application.Attributes;
using Flx.Delivery.Application.Exceptions;
using Flx.Delivery.Application.Interfaces.Accessors;
using Flx.Delivery.Application.Interfaces.Repositories;
using Flx.Delivery.Domain.Entities;
using Flx.Delivery.Domain.Enums;
using Flx.Delivery.Identity.Accessors;
using MediatR;
using Rovecode.Lotos.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
                    var user = (await _userStorage.PickViaAccessToken(_authAccessor.AccessToken!))!;

                    foreach (RoleType item in authAttribute.Roles)
                    {
                        if (!user.IsHasRole(item))
                        {
                            throw new AuthDeliveryException();
                        }
                    }

                    return await next();
                }
                else return await next();
            }
            else return await next();
        }

        public async Task ThrowIfTokenNotExistsOrNull(string? token)
        {
            if (token is null || !await _accessTokenStorage.Exists(e => e.Token == token))
            {
                throw new AuthDeliveryException();
            }
        }
    }
}
