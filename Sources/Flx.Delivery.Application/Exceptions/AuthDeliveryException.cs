﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flx.Delivery.Application.Exceptions
{
    public sealed class AuthDeliveryException : DeliveryException
    {
        public AuthDeliveryException() : base("Unauth")
        {

        }
    }
}
