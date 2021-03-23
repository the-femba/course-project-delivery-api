using Flx.Delivery.Application.Interfaces.Accessors;
using Flx.Delivery.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Rovecode.Lotos.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            try
            {
                string authHeader = _httpContextAccessor.HttpContext.Request.Headers["Authorization"];

                if (authHeader.Length <= TokenSecretWord.Length || !authHeader.StartsWith(TokenSecretWord))
                {
                    return null;
                }

                string token = authHeader.Remove(0, TokenSecretWord.Length);

                return token;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
