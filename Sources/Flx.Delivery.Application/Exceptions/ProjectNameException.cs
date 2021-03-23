using System;

namespace Flx.Delivery.Application.Exceptions
{
    /// <summary>
    /// Класс ошибки для @Delivery.
    /// </summary>
    public class DeliveryException : Exception
    {
        public int Status { get; }

        public DeliveryException(int status = 500) : base()
        {
            Status = status;
        }

        public DeliveryException(string message, int status = 500) : base(message)
        {
            Status = status;
        }
    }
}
