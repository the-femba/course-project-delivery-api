namespace Flx.Delivery.Application.Exceptions
{
    public sealed class NotExistsDeliveryException : DeliveryException
    {
        public NotExistsDeliveryException(string message) : base(message)
        {

        }

        public NotExistsDeliveryException() : base("object not exists")
        {

        }
    }
}
