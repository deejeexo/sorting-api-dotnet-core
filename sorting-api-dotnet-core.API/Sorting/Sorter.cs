namespace sorting_api_dotnet_core.API;

public class Sorter
{
    public void Sort<T>(IList<T> items, Algorithms algorithm)
        where T : IComparable<T>
    {
        var sortAlgorithm = SortAlgorithmFactory.GetSortAlgorithm(algorithm);
        sortAlgorithm.Sort(items);
    }
}
