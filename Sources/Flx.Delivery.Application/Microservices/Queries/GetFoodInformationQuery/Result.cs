using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flx.Delivery.Application.Microservices.Queries.GetFoodInformationQuery
{
    public sealed class Result
    {
        public string FoodPhotoBase64 { get; set; } = null!;

        public string Name { get; set; } = null!;

        public double PriceGrn { get; set; }
    }
}
