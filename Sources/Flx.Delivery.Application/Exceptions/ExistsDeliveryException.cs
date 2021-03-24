namespace Flx.Delivery.Application.Exceptions
{
    public sealed class ExistsDeliveryException : DeliveryException
    {
        public ExistsDeliveryException(string message) : base(message)
        {

        }

        public ExistsDeliveryException() : base("object already exists")
        {

        }
    }
}
