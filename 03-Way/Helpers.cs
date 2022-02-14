namespace _03_Way;

public static class Helpers
{
    private static readonly Random Random = new Random(Guid.NewGuid().GetHashCode());

    public static string RandomString(int length = 10)
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        return new string(Enumerable.Repeat(chars, length)
            .Select(s => s[Random.Next(s.Length)]).ToArray());
    }

    public static bool IsProduction()
    {
        var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
        return string.Equals(environment, Environments.Production, StringComparison.OrdinalIgnoreCase);
    }
}