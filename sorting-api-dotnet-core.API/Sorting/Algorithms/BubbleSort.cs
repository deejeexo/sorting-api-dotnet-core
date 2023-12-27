namespace sorting_api_dotnet_core.API;

public class BubbleSort : ISortAlgorithm
{
    public void Sort<T>(IList<T> items)
        where T : IComparable<T>
    {
        ExecuteBubbleSort(items);
    }

    private static void ExecuteBubbleSort<T>(IList<T> items)
        where T : IComparable<T>
    {
        int n = items.Count;
        for (int i = 0; i < n - 1; i++)
        {
            for (int j = 0; j < n - i - 1; j++)
            {
                if (items[j].CompareTo(items[j + 1]) > 0)
                {
                    (items[j + 1], items[j]) = (items[j], items[j + 1]);
                }
            }
        }
    }
}
