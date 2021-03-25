using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flx.Delivery.Domain.Enums
{
    public enum OrderStatus
    {
        Validation,
        СourierGoesToRestaurant,
        RestaurantPreparesFood,
        СourierGoesToCustomer,
        Done,
        Cancel,
    }
}
