namespace sorting_api_dotnet_core.Benchmark;

public static class Utils
{
    public static IList<int> GenerateRandomIntegers(int count, int min, int max)
    {
        var random = new Random();
        var data = new List<int>();
        for (var i = 0; i < count; i++)
        {
            data.Add(random.Next(min, max));
        }

        return data;
    }
}
