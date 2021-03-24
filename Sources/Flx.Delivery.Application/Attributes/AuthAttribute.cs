using Flx.Delivery.Application.Enums;
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
        public IEnumerable<RoleType>? Roles { get; }
        public RoleCheckStrategy CheckStrategy { get; set; } = RoleCheckStrategy.OneMatch;

        public AuthAttribute()
        {

        }

        public AuthAttribute(params RoleType[] roles)
        {
            Roles = roles;
        }
    }
}
