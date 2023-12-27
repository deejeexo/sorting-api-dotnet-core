namespace sorting_api_dotnet_core.API.Tests
{
    public class SorterTests
    {
        [Fact]
        public void Sort_UsingBubbleSort_SortsItemsCorrectly()
        {
            var sorter = new Sorter();
            var items = new List<int> { 5, 2, 8, 1, 9 };

            sorter.Sort(items, Algorithms.BubbleSort);

            var expected = new List<int> { 1, 2, 5, 8, 9 };
            Assert.Equal(expected, items);
        }

        [Fact]
        public void Sort_UsingSelectionSort_SortsItemsCorrectly()
        {
            var sorter = new Sorter();
            var items = new List<int> { 5, 2, 8, 1, 9 };

            sorter.Sort(items, Algorithms.SelectionSort);

            var expected = new List<int> { 1, 2, 5, 8, 9 };
            Assert.Equal(expected, items);
        }

        [Fact]
        public void Sort_UsingInsertionSort_SortsItemsCorrectly()
        {
            var sorter = new Sorter();
            var items = new List<int> { 5, 2, 8, 1, 9 };

            sorter.Sort(items, Algorithms.InsertionSort);

            var expected = new List<int> { 1, 2, 5, 8, 9 };
            Assert.Equal(expected, items);
        }

        [Fact]
        public void Sort_UsingMergeSort_SortsItemsCorrectly()
        {
            var sorter = new Sorter();
            var items = new List<int> { 5, 2, 8, 1, 9 };

            sorter.Sort(items, Algorithms.MergeSort);

            var expected = new List<int> { 1, 2, 5, 8, 9 };
            Assert.Equal(expected, items);
        }

        [Fact]
        public void Sort_UsingQuickSort_SortsItemsCorrectly()
        {
            var sorter = new Sorter();
            var items = new List<int> { 5, 2, 8, 1, 9 };

            sorter.Sort(items, Algorithms.QuickSort);

            var expected = new List<int> { 1, 2, 5, 8, 9 };
            Assert.Equal(expected, items);
        }
    }
}
