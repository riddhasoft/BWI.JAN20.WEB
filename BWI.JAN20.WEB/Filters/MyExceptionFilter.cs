using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BWI.JAN20.WEB.Filters
{
    public class MyExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            context.Result = new RedirectToRouteResult(
                                       new RouteValueDictionary
                                       {
                                    {"Area","" },
                                    {"controller", "home"},
                                    {"action", "Error"}
                                       }
                                   );
        }
    }
}
