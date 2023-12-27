namespace sorting_api_dotnet_core.API;

public class QuickSort : ISortAlgorithm
{
    public void Sort<T>(IList<T> items)
        where T : IComparable<T>
    {
        ExecuteQuickSort(items, 0, items.Count - 1);
    }

    private void ExecuteQuickSort<T>(IList<T> items, int left, int right)
        where T : IComparable<T>
    {
        if (left < right)
        {
            int pivotIndex = Partition(items, left, right);
            ExecuteQuickSort(items, left, pivotIndex - 1);
            ExecuteQuickSort(items, pivotIndex + 1, right);
        }
    }

    private static int Partition<T>(IList<T> items, int left, int right)
        where T : IComparable<T>
    {
        T pivot = items[right];
        int i = left - 1;

        for (int j = left; j < right; j++)
        {
            if (items[j].CompareTo(pivot) <= 0)
            {
                i++;
                Swap(items, i, j);
            }
        }

        Swap(items, i + 1, right);
        return i + 1;
    }

    private static void Swap<T>(IList<T> items, int i, int j)
    {
        (items[j], items[i]) = (items[i], items[j]);
    }
}
