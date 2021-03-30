namespace Flx.Delivery.Domain.Enums
{
    public enum OrderStatus
    {
        SearchForCourier = 0,
        СourierGoesToRestaurant = 1,
        СourierCameToRestaurant = 2,
        RestaurantPreparesFood = 3,
        RestaurantPreparedFood = 5,
        СourierGoesToCustomer = 6,
        Done = -1,
        Cancel = -2,
    }
}
