namespace sorting_api_dotnet_core.API;

public static class SortAlgorithmFactory
{
    public static ISortAlgorithm GetSortAlgorithm(Algorithms algorithm)
    {
        return algorithm switch
        {
            Algorithms.BubbleSort => new BubbleSort(),
            Algorithms.SelectionSort => new SelectionSort(),
            Algorithms.InsertionSort => new InsertionSort(),
            Algorithms.MergeSort => new MergeSort(),
            Algorithms.QuickSort => new QuickSort(),
            _ => throw new ArgumentOutOfRangeException(nameof(algorithm), algorithm, null)
        };
    }
}
