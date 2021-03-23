using Flx.Delivery.Application.Interfaces.Repositories;
using Flx.Delivery.Domain.Entities;
using Rovecode.Lotos.Contexts;
using Rovecode.Lotos.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flx.Delivery.Persistence.Repositories
{
    public sealed class UserEntityStorage : Storage<UserEntity>, IUserEntityStorage
    {
        private readonly IStorage<AccessTokenEntity> _accessTokenStorage;

        public UserEntityStorage(StorageContext<UserEntity> storageContext, IStorage<AccessTokenEntity> accessTokenStorage) : base(storageContext)
        {
            _accessTokenStorage = accessTokenStorage;
        }

        public async Task<UserEntity?> PickViaAccessToken(string accessToken)
        {
            var token = await _accessTokenStorage.Pick(e => e.Token == accessToken);

            if (token is null)
            {
                return null;
            }
            else
            {
                return await Pick(token.UserId);
            }
        }
    }
}
