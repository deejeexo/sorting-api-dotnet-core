using System.Text;
using System.Text.Json;

namespace sorting_api_dotnet_core.Tests;

public static class Utils
{
    public static StringContent GetJsonStringContent<T>(T model) =>
        new(JsonSerializer.Serialize(model), Encoding.UTF8, "application/json");
}
