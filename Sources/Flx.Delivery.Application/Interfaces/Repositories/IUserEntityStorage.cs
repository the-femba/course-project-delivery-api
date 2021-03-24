using Flx.Delivery.Domain.Entities;
using Rovecode.Lotos.Repositories;
using System.Threading.Tasks;

namespace Flx.Delivery.Application.Interfaces.Repositories
{
    public interface IUserEntityStorage : IStorage<UserEntity>
    {
        public Task<UserEntity?> PickViaAccessToken(string accessToken);
    }
}
