﻿using Flx.Delivery.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flx.Delivery.Application.Microservices.Queries.GetOrderStatusQuery
{
    public sealed class Result
    {
        public OrderStatus OrderStatus { get; set; }
    }
}