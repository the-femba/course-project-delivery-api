using Flx.Delivery.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flx.Delivery.Application.Attributes
{
    public sealed class AuthAttribute : Attribute
    {
        public IReadOnlyList<RoleType>? Roles { get; }

        public AuthAttribute()
        {

        }

        public AuthAttribute(params RoleType[] roles)
        {
            Roles = roles;
        }
    }
}
