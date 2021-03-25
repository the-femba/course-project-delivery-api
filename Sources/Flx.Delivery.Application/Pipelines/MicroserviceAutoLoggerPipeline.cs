using Flx.Delivery.Application.Interfaces.Accessors;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Flx.Delivery.Application.Pipelines
{
    public sealed class MicroserviceAutoLoggerPipeline<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly ILogger<IRequest> _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IHttpAuthAccessor _authAccessor;

        public MicroserviceAutoLoggerPipeline(ILogger<IRequest> logger, IHttpContextAccessor httpContextAccessor, IHttpAuthAccessor authAccessor)
        {
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;
            _authAccessor = authAccessor;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            _logger.LogInformation($"Invoke Method {request.GetType().Namespace} from {_httpContextAccessor.HttpContext.Connection.RemoteIpAddress} ip with token {_authAccessor.AccessToken ?? "none"}");

            return await next();
        }
    }
}
