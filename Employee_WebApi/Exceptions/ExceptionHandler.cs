using Employee_WebApi.Model;
using Microsoft.AspNetCore.Diagnostics;
using System.ComponentModel.DataAnnotations;

namespace Employee_WebApi.Exceptions
{
    public class ExcecptionHandler : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext,
     Exception exception, CancellationToken cancellationToken)
        {
            var response = new ErrorResponse();
            if (exception is ValidationException)
            {
                response.Statuscode = StatusCodes.Status400BadRequest;
                response.Title = "Invalid Input";
                response.ExceptionMessage = exception.Message;
            }
            else if (exception is InvalidInputException)
            {
                response.Statuscode = StatusCodes.Status404NotFound;
                response.Title = "Wrong Input";
                response.ExceptionMessage = exception.Message;
            }
            else
            {
                response.Statuscode = StatusCodes.Status500InternalServerError;
                response.Title = "Something went Wrong";
                response.ExceptionMessage = exception.Message;
            }
            await httpContext.Response.WriteAsJsonAsync(response, cancellationToken);
            return true;
        }
    }
}
