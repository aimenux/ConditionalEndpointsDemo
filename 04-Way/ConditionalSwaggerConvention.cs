using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.FeatureManagement.Mvc;

namespace _04_Way;

public sealed class ConditionalSwaggerConvention : IActionModelConvention
{
    public void Apply(ActionModel action)
    {
        if (!Helpers.IsProduction()) return;

        var attributes = action.Controller.ControllerType
            .GetCustomAttributes(typeof(FeatureGateAttribute), false)
            .OfType<FeatureGateAttribute>()
            .ToList();

        if (attributes.Any(x => x.Features.Contains(FeatureFlags.AwesomeFeature)))
        {
            action.ApiExplorer.IsVisible = false;
        }
    }
}