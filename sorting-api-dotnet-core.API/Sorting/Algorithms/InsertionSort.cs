namespace sorting_api_dotnet_core.API;

public class InsertionSort : ISortAlgorithm
{
    public void Sort<T>(IList<T> items)
        where T : IComparable<T>
    {
        ExecuteInsertionSort(items);
    }

    private static void ExecuteInsertionSort<T>(IList<T> items)
        where T : IComparable<T>
    {
        int n = items.Count;
        for (int i = 1; i < n; ++i)
        {
            T key = items[i];
            int j = i - 1;

            while (j >= 0 && items[j].CompareTo(key) > 0)
            {
                items[j + 1] = items[j];
                j--;
            }
            items[j + 1] = key;
        }
    }
}
