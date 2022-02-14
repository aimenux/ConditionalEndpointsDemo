using Microsoft.FeatureManagement;

namespace _04_Way;

[FilterAlias("ConditionalAlias")]
public class ConditionalFeatureFilter : IFeatureFilter
{
    public Task<bool> EvaluateAsync(FeatureFilterEvaluationContext context)
    {
        var isEnabled = !Helpers.IsProduction();
        return Task.FromResult(isEnabled);
    }
}