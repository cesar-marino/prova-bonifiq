using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using ProvaPub.Domain.Exceptions;

namespace ProvaPub.Presentation.API.Filters
{
    public class ApiGlobalExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            var details = new ProblemDetails();
            var exception = context.Exception;

            if (exception is EntityValidationException entityValidation)
            {
                details.Title = entityValidation?.Code;
                details.Status = StatusCodes.Status422UnprocessableEntity;
                details.Type = entityValidation?.GetType().ToString();
                details.Detail = entityValidation?.Message;
            }
            else if (exception is NotFoundException notFound)
            {
                details.Title = notFound?.Code;
                details.Status = StatusCodes.Status404NotFound;
                details.Type = notFound?.GetType().ToString();
                details.Detail = notFound?.Message;
            }
            else if (exception is UnexpectedException unexpected)
            {
                details.Title = unexpected?.Code;
                details.Status = StatusCodes.Status500InternalServerError;
                details.Type = unexpected?.GetType().ToString();
                details.Detail = unexpected?.Message;
            }
            else
            {
                details.Title = "unexpected";
                details.Status = StatusCodes.Status500InternalServerError;
                details.Type = "UnexpectedException";
                details.Detail = exception.Message;
                details.Instance = exception.Source;
            }

            context.HttpContext.Response.StatusCode = (int)details.Status!;
            context.Result = new ObjectResult(details);
            context.ExceptionHandled = true;
        }
    }
}
