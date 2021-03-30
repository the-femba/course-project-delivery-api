using Rovecode.Lotos.Entities;

namespace Flx.Delivery.Domain.Entities
{
    public sealed class FoodEntity : StorageEntity<FoodEntity>
    {
        public string FoodPhotoName { get; set; } = null!;

        public string Name { get; set; } = null!;

        public double PriceGrn { get; set; }
    }
}
