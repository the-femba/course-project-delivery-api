using Rovecode.Lotos.Entities;
using System;

namespace Flx.Delivery.Domain.Entities
{
    public sealed class AccessTokenEntity : StorageEntity<AccessTokenEntity>
    {
        public Guid UserId { get; set; }

        public string Token { get; set; } = null!;
    }
}
