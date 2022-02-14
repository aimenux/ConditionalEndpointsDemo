using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using _01_Way.Controllers;

namespace _01_Way;

public class ConditionalControllerProvider : ControllerFeatureProvider
{
    protected override bool IsController(TypeInfo typeInfo)
    {
        var isController = base.IsController(typeInfo);

        if (isController && Helpers.IsProduction())
        {
            return !IsController<TestingController>(typeInfo);
        }

        return isController;
    }

    private static bool IsController<T>(MemberInfo typeInfo) where T : ControllerBase
    {
        return string.Equals(typeInfo.Name, typeof(T).Name, StringComparison.OrdinalIgnoreCase);
    }
}