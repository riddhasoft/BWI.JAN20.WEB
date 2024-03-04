using Microsoft.AspNetCore.Mvc.Filters;

namespace BWI.JAN20.WEB.Filters
{
    public class MyActionFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
           
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            
        }
    }
}
