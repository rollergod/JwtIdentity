using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace JwtIdentity.Api.Filters
{
    public class ModelStateFilter : IActionFilter
    {

        public void OnActionExecuted(ActionExecutedContext context)
        {
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            // var action = context.RouteData.Values["action"];
            // var controller = context.RouteData.Values["controller"];

            if (!context.ModelState.IsValid)
                context.Result = new UnprocessableEntityObjectResult(context.ModelState);
        }
    }
}