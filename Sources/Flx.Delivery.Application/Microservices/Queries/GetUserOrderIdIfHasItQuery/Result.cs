﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flx.Delivery.Application.Microservices.Queries.GetUserOrderIdIfHasItQuery
{
    public sealed class Result
    {
        public Guid? OrderId { get; set; }
    }
}
