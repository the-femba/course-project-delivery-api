using Flx.Delivery.Domain.Enums;
using Rovecode.Lotos.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Flx.Delivery.Domain.Entities
{
    public sealed class UserEntity : StorageEntity<UserEntity>
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;

        public string Email { get; set; } = null!;

        // pref sha256 string
        public string PasswordHash { get; set; } = null!;

        public IEnumerable<RoleType> Roles { get; set; } = null!;

        public bool IsHasRole(RoleType roleType)
        {
            return Roles is not null && Roles.Count() > 0
                ? Roles.Contains(roleType)
                : false;
        }
    }
}
