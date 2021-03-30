using Flx.Delivery.Application.Interfaces.Accessors;

namespace Flx.Delivery.Application.Tests.Fakes
{
    public class HttpAuthAccessorFake : IHttpAuthAccessor
    {
        public string AccessToken { get; }

        public HttpAuthAccessorFake(string token)
        {
            AccessToken = token;
        }
    }
}
