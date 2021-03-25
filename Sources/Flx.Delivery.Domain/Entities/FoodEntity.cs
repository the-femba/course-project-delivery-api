using Rovecode.Lotos.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flx.Delivery.Domain.Entities
{
    public sealed class FoodEntity : StorageEntity<FoodEntity>
    {
        public string FoodPhotoName { get; set; } = null!;

        public string Name { get; set; } = null!;

        public double PriceGrn { get; set; }
    }
}
