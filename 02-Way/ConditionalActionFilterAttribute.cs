using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace _02_Way;

public sealed class ConditionalActionFilterAttribute : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        if (Helpers.IsProduction())
        {
            context.Result = new NotFoundResult();
            return;
        }

        base.OnActionExecuting(context);
    }
}