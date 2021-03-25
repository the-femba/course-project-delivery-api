using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flx.Delivery.Application.Models
{
    public sealed class OneResult<T>
    {
        public T? Result { get; set; }
    }
}
