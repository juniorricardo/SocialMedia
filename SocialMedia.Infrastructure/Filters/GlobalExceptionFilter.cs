using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using SocialMedia.Core.Exceptions;

namespace SocialMedia.Infrastructure.Filters
{
    public class GlobalExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if (context.Exception.GetType() != typeof(BusinessException)) return;
            var exception = (BusinessException)context.Exception;
            var validation = new
            {
                Status = (int)HttpStatusCode.BadRequest,
                Title = HttpStatusCode.BadRequest.ToString(),
                Detail = exception.Message
            };

            var json = new
            {
                errors = new[] { validation }
            };
            context.Result = new BadRequestObjectResult(json);
            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            context.ExceptionHandled = true;
        }
    }
}
