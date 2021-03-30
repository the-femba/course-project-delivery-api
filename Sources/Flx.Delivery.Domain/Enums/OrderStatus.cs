namespace Flx.Delivery.Domain.Enums
{
    public enum OrderStatus
    {
        SearchForCourier = 0,
        CourierGoesToRestaurant = 1,
        CourierCameToRestaurant = 2,
        RestaurantPreparesFood = 3,
        RestaurantPreparedFood = 5,
        CourierGoesToCustomer = 6,
        Done = -1,
        Cancel = -2,
    }
}
