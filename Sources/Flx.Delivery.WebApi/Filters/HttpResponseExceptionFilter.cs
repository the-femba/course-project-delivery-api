using FluentValidation;
using Flx.Delivery.Application.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace Flx.Delivery.WebApi.Filters
{

    public class HttpResponseExceptionFilter : IActionFilter, IOrderedFilter
    {
        private readonly ILogger<HttpResponseExceptionFilter> _logger;

        public HttpResponseExceptionFilter(ILogger<HttpResponseExceptionFilter> logger)
        {
            _logger = logger;
        }

        public int Order { get; } = int.MaxValue - 10;

        public void OnActionExecuting(ActionExecutingContext context)
        {

        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Exception is DeliveryException DeliveryException)
            {
                context.Result = ExceptionToResult(DeliveryException, DeliveryException.Status);
                context.ExceptionHandled = true;
            }
            else if (context.Exception is ValidationException validationException)
            {
                context.Result = ExceptionToResult(validationException, 403);
                context.ExceptionHandled = true;
            }
        }

        private IActionResult ExceptionToResult(Exception exception, int code)
        {
            var json = new Dictionary<string, dynamic>
            {
                { "code", code },
                { "errorType", exception.GetType().Name },
                { "errorMessage", exception.Message }
            };

            _logger.LogError($"Handle error with type \'{json["errorType"]}\' and http code \'{json["code"]}\'");

            var result = new JsonResult(json)
            {
                StatusCode = code,
            };

            return result;
        }
    }
}
