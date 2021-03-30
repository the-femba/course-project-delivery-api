namespace Flx.Delivery.Application.Microservices.Queries.GetFoodInformationQuery
{
    public sealed class Result
    {
        public string FoodPhotoBase64 { get; set; } = null!;

        public string Name { get; set; } = null!;

        public double PriceGrn { get; set; }
    }
}
