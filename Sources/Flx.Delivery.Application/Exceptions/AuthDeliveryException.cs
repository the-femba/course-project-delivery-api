namespace Flx.Delivery.Application.Exceptions
{
    public sealed class AuthDeliveryException : DeliveryException
    {
        public AuthDeliveryException() : base("Unauth")
        {

        }
    }
}
