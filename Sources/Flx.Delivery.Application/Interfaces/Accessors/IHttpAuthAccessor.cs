using Flx.Delivery.Domain.Entities;
using Flx.Delivery.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flx.Delivery.Application.Interfaces.Accessors
{
    public interface IHttpAuthAccessor
    {
        public string? AccessToken { get; }
    }
}
