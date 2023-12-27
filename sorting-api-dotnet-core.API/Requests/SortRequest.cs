namespace sorting_api_dotnet_core.API;

public class SortRequest
{
    public Algorithms Algorithm { get; set; }

    public IList<int> Items { get; set; } = new List<int>();
}
