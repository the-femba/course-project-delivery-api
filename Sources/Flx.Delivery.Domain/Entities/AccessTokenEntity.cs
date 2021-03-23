using Rovecode.Lotos.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flx.Delivery.Domain.Entities
{
    public sealed class AccessTokenEntity : StorageEntity<AccessTokenEntity>
    {
        public Guid UserId { get; set; }

        public string Token { get; set; } = null!;
    }
}
