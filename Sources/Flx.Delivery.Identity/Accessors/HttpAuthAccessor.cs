using Flx.Delivery.Application.Interfaces.Accessors;
using Microsoft.AspNetCore.Http;

namespace Flx.Delivery.Identity.Accessors
{
    public sealed class HttpAuthAccessor : IHttpAuthAccessor
    {
        private const string TokenSecretWord = "Bearer ";

        public string? AccessToken { get; }

        private readonly IHttpContextAccessor _httpContextAccessor;

        public HttpAuthAccessor(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;

            AccessToken = GetAccessToken();
        }

        private string? GetAccessToken()
        {
            if (_httpContextAccessor.HttpContext is null)
            {
                return null;
            }

            if (!_httpContextAccessor.HttpContext.Request.Headers.ContainsKey("Authorization"))
            {
                return null;
            }

            string authHeader = _httpContextAccessor.HttpContext.Request.Headers["Authorization"];

            if (authHeader.Length <= TokenSecretWord.Length || !authHeader.StartsWith(TokenSecretWord))
            {
                return null;
            }

            string token = authHeader.Remove(0, TokenSecretWord.Length);

            return token;
        }
    }
}
