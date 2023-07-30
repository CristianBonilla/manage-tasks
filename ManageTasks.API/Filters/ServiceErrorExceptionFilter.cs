using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using ManageTasks.Contracts.Exceptions;
using ManageTasks.Contracts.Services;

namespace ManageTasks.API.Filters
{
  public class ServiceErrorExceptionFilter : IActionFilter, IOrderedFilter
  {
    public int Order => int.MaxValue - 10;

    public void OnActionExecuting(ActionExecutingContext context) { }

    public void OnActionExecuted(ActionExecutedContext context)
    {
      if (context.Exception is ServiceErrorException exception)
      {
        ServiceError serviceError = exception.ServiceError;
        context.Result = new ObjectResult(serviceError)
        {
          StatusCode = serviceError.StatusCode
        };
        context.ExceptionHandled = true;
      }
    }
  }
}
