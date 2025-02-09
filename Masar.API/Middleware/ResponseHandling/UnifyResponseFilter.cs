using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace Masar.API.Middleware.ResponseHandling
{
    public class UnifyResponseFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
           
            
          
            if (context.Result is ObjectResult objectResult)
            {
                // Wrap successful responses
                context.Result = new ObjectResult(new ApiResponse
                {
                    Success = true,
                    Message = "Operation successful",
                    Content = objectResult.Value
                })
                {
                    StatusCode = objectResult.StatusCode
                };
            } 
            else if (context.Result is EmptyResult)
            {
                // Handle cases where no data is returned
                context.Result = new ObjectResult(new ApiResponse
                {
                    Success = true,
                    Message = "Operation successful",
                    Content = null
                })
                {
                    StatusCode = 204 // No Content
                };
            }
            else if (context.Exception != null)
            {
                // Wrap unhandled exceptions (optional)
                context.Result = new ObjectResult(new ApiResponse
                {
                    Success = false,
                    Message = context.Exception.Message,
                    Content = null
                })
                {
                    StatusCode = 500
                };

                //context.ExceptionHandled = true;
            }
            else if (context.Result.GetType() == typeof(Microsoft.AspNetCore.Mvc.FileStreamResult))
                return;

        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
        }
    }


    public class ApiResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public object Content { get; set; }

    }
 
}

   



