using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.AspNetCore.Mvc.Controllers;

namespace _01_Way;

public static class Extensions
{
    public static void UseConditionalControllerProvider(this ApplicationPartManager config)
    {
        var defaultControllerProvider = config.FeatureProviders.FirstOrDefault(x => x is ControllerFeatureProvider);
        if (defaultControllerProvider is not null)
        {
            config.FeatureProviders.Remove(defaultControllerProvider);
        }
            
        config.FeatureProviders.Add(new ConditionalControllerProvider());
    }
}