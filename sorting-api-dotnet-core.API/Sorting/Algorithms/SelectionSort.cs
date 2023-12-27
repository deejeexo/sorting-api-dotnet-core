namespace sorting_api_dotnet_core.API;

public class SelectionSort : ISortAlgorithm
{
    public void Sort<T>(IList<T> items)
        where T : IComparable<T>
    {
        ExecuteSelectionSort(items);
    }

    private static void ExecuteSelectionSort<T>(IList<T> items)
        where T : IComparable<T>
    {
        int n = items.Count;
        for (int i = 0; i < n - 1; i++)
        {
            int minIndex = i;
            for (int j = i + 1; j < n; j++)
            {
                if (items[j].CompareTo(items[minIndex]) < 0)
                {
                    minIndex = j;
                }
            }
            (items[i], items[minIndex]) = (items[minIndex], items[i]);
        }
    }
}
