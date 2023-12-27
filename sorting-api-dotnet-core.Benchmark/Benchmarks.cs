using BenchmarkDotNet.Attributes;
using sorting_api_dotnet_core.API;

namespace sorting_api_dotnet_core.Benchmark;

[Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.FastestToSlowest)]
public class Benchmarks
{
    private IList<int>? data;

    [Params(10000, 50000, 100000)]
    public int N;

    [Params(
        Algorithms.BubbleSort,
        Algorithms.InsertionSort,
        Algorithms.SelectionSort,
        Algorithms.MergeSort,
        Algorithms.QuickSort
    )]
    public Algorithms SortingAlgorithm;

    [GlobalSetup]
    public void Setup()
    {
        data = Utils.GenerateRandomIntegers(N, 0, 10);
    }

    [Benchmark]
    public void SortBenchmark()
    {
        var sorter = new Sorter();
        var list = new List<int>(data!);
        sorter.Sort(list!, SortingAlgorithm);
    }
}
