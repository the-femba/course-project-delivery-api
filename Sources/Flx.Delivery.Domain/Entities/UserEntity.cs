using Rovecode.Lotos.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flx.Delivery.Domain.Entities
{
    public sealed class UserEntity : StorageEntity<UserEntity>
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;

        public string Email { get; set; } = null!;

        // pref sha256 string
        public string PasswordHash { get; set; } = null!;
    }
}
