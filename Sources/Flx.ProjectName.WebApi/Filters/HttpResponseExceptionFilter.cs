using System;
using System.Collections.Generic;
using FluentValidation;
using Flx.ProjectName.Application.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Flx.ProjectName.WebApi.Filters
{
    public class HttpResponseExceptionFilter : IActionFilter, IOrderedFilter
    {
        public int Order { get; } = int.MaxValue - 10;

        public void OnActionExecuting(ActionExecutingContext context) { }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Exception is ProjectNameException ProjectNameException)
            {
                context.Result = ExceptionToResult(ProjectNameException, ProjectNameException.Status);
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
            json.Add("error", exception.GetType().Name.Replace("Exception", ""));
            json.Add("message", exception.Message);
            json.Add("stackTrace", exception.StackTrace);

            var result = new JsonResult(json)
            {
                StatusCode = code,
            };

            return result;
        }
    }
}
