using Rovecode.Lotos.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flx.Delivery.Domain.Entities
{
    public sealed class RestaurantEntity : StorageEntity<RestaurantEntity>
    {
        public sealed class RestaurantInformation
        {
            public string Name { get; set; } = null!;
            public string Description { get; set; } = null!;
        }

        public sealed class RestaurantPhotos
        {
            public string LogoPhotoName { get; set; } = null!;
            public string BackwardPhotoName { get; set; } = null!;
        }

        public RestaurantInformation Information { get; set; } = new();
        public RestaurantPhotos Photos { get; set; } = new();

        public IEnumerable<Guid> FoodsIds { get; set; } = new Guid[] { };

        public IEnumerable<Guid> RestaurateursIds { get; set; } = new Guid[] { };
    }
}
