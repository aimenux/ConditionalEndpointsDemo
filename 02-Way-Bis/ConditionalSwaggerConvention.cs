using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace _02_Way_Bis;

public sealed class ConditionalSwaggerConvention : IActionModelConvention
{
    public void Apply(ActionModel action)
    {
        if (!Helpers.IsProduction()) return;

        var attributes = action.Controller.ControllerType.GetCustomAttributes(typeof(ConditionalActionFilterAttribute), false);
        if (attributes.Any())
        {
            action.ApiExplorer.IsVisible = false;
        }
    }
}