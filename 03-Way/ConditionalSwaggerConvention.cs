using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace _03_Way;

public sealed class ConditionalSwaggerConvention : IActionModelConvention
{
    public void Apply(ActionModel action)
    {
        if (!Helpers.IsProduction()) return;

        var attributes = action.Controller.ControllerType.GetCustomAttributes(typeof(ConditionalControllerAttribute), false);
        if (attributes.Any())
        {
            action.ApiExplorer.IsVisible = false;
        }
    }
}