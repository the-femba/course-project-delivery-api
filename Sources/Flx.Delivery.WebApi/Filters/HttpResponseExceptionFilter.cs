﻿using System;
using System.Collections.Generic;
using FluentValidation;
using Flx.Delivery.Application.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Flx.Delivery.WebApi.Filters
{
    public class HttpResponseExceptionFilter : IActionFilter, IOrderedFilter
    {
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
            var json = new Dictionary<string, dynamic>();

            json.Add("code", code);
            json.Add("isError", "true");
            json.Add("errorType", exception.GetType().Name);
            json.Add("errorMessage", exception.Message);
            // json.Add("stackTrace", exception.StackTrace);

            var result = new JsonResult(json)
            {
                StatusCode = code,
            };

            return result;
        }
    }
}
