using Flx.Delivery.Domain.Enums;
using Rovecode.Lotos.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flx.Delivery.Domain.Entities
{
    public sealed class OrderEntity : StorageEntity<OrderEntity>
    {
        public DateTime CreateDate { get; set; }

        public DateTime? CloseDate { get; set; }

        public Guid RestaurantId { get; set; }

        public Guid CustomerId { get; set; }

        public Guid? CourierId { get; set; }

        public OrderStatus Status { get; set; }

        public IEnumerable<Guid> OrderFoodsIds { get; set; } = new Guid[] { };
    }
}
