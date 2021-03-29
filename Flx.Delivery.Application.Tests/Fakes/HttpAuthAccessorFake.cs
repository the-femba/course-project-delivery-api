using Flx.Delivery.Application.Interfaces.Accessors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
