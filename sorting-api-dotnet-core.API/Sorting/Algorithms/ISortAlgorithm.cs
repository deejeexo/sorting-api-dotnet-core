namespace sorting_api_dotnet_core.API;

public interface ISortAlgorithm
{
    void Sort<T>(IList<T> items)
        where T : IComparable<T>;
}
