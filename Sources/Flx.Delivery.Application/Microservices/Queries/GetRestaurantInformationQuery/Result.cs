using Flx.Delivery.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flx.Delivery.Application.Microservices.Queries.GetRestaurantInformationQuery
{
    public sealed class Result
    {
        public sealed class RestaurantPhotosData
        {
            public string LogoPhotoBase64 { get; set; } = null!;
            public string BackwardPhotoBase64 { get; set; } = null!;
        }

        public RestaurantEntity.RestaurantInformation Information { get; set; } = null!;

        public RestaurantPhotosData PhotosData { get; set; } = null!;
    }
}
