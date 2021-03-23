using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flx.Delivery.Application.Exceptions
{
    public sealed class ExistsDeliveryException : DeliveryException
    {
        public ExistsDeliveryException(string message) : base(message)
        {

        }

        public ExistsDeliveryException() : base("object already exists")
        {

        }
    }
}
