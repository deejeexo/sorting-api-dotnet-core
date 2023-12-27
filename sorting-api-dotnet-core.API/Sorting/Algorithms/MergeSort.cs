namespace sorting_api_dotnet_core.API;

public class MergeSort : ISortAlgorithm
{
    public void Sort<T>(IList<T> items)
        where T : IComparable<T>
    {
        ExecuteMergeSort(items);
    }

    private static void ExecuteMergeSort<T>(IList<T> items)
        where T : IComparable<T>
    {
        int n = items.Count;
        if (n < 2)
        {
            return;
        }
        int mid = n / 2;
        IList<T> left = new List<T>(mid);
        IList<T> right = new List<T>(n - mid);

        for (int i = 0; i < mid; i++)
        {
            left.Add(items[i]);
        }
        for (int i = mid; i < n; i++)
        {
            right.Add(items[i]);
        }
        ExecuteMergeSort(left);
        ExecuteMergeSort(right);
        Merge(items, left, right);
    }

    private static void Merge<T>(IList<T> items, IList<T> left, IList<T> right)
        where T : IComparable<T>
    {
        int nL = left.Count;
        int nR = right.Count;
        int i = 0,
            j = 0,
            k = 0;

        while (i < nL && j < nR)
        {
            if (left[i].CompareTo(right[j]) <= 0)
            {
                items[k] = left[i];
                i++;
            }
            else
            {
                items[k] = right[j];
                j++;
            }
            k++;
        }
        while (i < nL)
        {
            items[k] = left[i];
            i++;
            k++;
        }
        while (j < nR)
        {
            items[k] = right[j];
            j++;
            k++;
        }
    }
}
