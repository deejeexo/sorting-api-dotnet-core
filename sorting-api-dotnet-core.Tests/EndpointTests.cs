using System.Net;
using sorting_api_dotnet_core.Tests;
using static sorting_api_dotnet_core.API.Endpoints;
using static sorting_api_dotnet_core.Tests.Utils;

namespace sorting_api_dotnet_core.API.Tests
{
    public class SortEndpointsTests
    {
        private readonly SortingApiFactory _sortingApi = new();

        [Fact]
        public async Task Sort_ValidRequest_ReturnsOkResult()
        {
            var request = new SortRequest
            {
                Algorithm = Algorithms.BubbleSort,
                Items = new[] { 3, 1, 2 }
            };

            var result = await _sortingApi
                .CreateClient()
                .PostAsync(
                    $"{SORTING_GROUP}{SORT}",
                    GetJsonStringContent(request),
                    CancellationToken.None
                );

            Assert.Equal(HttpStatusCode.OK, result.StatusCode);
        }

        [Fact]
        public async Task GetLatestResult_ValidRequest_ReturnsOkResult()
        {
            var result = await _sortingApi
                .CreateClient()
                .GetAsync($"{SORTING_GROUP}{GET_LAST_SORTED_RESULT}", CancellationToken.None);

            Assert.Equal(HttpStatusCode.OK, result.StatusCode);
        }

        [Fact]
        public async Task Sort_ArrayMustContainAtLeastTwoElements_ReturnsBadRequest()
        {
            var request = new SortRequest
            {
                Algorithm = Algorithms.BubbleSort,
                Items = new[] { 3 }
            };

            var result = await _sortingApi
                .CreateClient()
                .PostAsync(
                    $"{SORTING_GROUP}{SORT}",
                    GetJsonStringContent(request),
                    CancellationToken.None
                );

            Assert.Equal(HttpStatusCode.BadRequest, result.StatusCode);

            var responseContent = await result.Content.ReadAsStringAsync();
            Assert.Contains("Items must contain at least 2 elements.", responseContent);
        }

        [Fact]
        public async Task Sort_ItemsCannotBeEmpty_ReturnsBadRequest()
        {
            var request = new SortRequest
            {
                Algorithm = Algorithms.BubbleSort,
                Items = Array.Empty<int>()
            };

            var result = await _sortingApi
                .CreateClient()
                .PostAsync(
                    $"{SORTING_GROUP}{SORT}",
                    GetJsonStringContent(request),
                    CancellationToken.None
                );

            Assert.Equal(HttpStatusCode.BadRequest, result.StatusCode);

            var responseContent = await result.Content.ReadAsStringAsync();
            Assert.Contains("Items cannot be empty.", responseContent);
        }

        [Fact]
        public async Task Sort_ItemsMustBeBetweenZeroAndTen_ReturnsBadRequest()
        {
            var request = new SortRequest
            {
                Algorithm = Algorithms.BubbleSort,
                Items = new[] { 3, 11, 12 }
            };

            var result = await _sortingApi
                .CreateClient()
                .PostAsync(
                    $"{SORTING_GROUP}{SORT}",
                    GetJsonStringContent(request),
                    CancellationToken.None
                );

            Assert.Equal(HttpStatusCode.BadRequest, result.StatusCode);

            var responseContent = await result.Content.ReadAsStringAsync();
            Assert.Contains("Items must be between 0 and 10.", responseContent);
        }

        [Fact]
        public async Task Sort_AlgorithmMustBeImplemented_ReturnsBadRequest()
        {
            var request = new SortRequest
            {
                Algorithm = (Algorithms)7,
                Items = new[] { 3, 11, 12 }
            };

            var result = await _sortingApi
                .CreateClient()
                .PostAsync(
                    $"{SORTING_GROUP}{SORT}",
                    GetJsonStringContent(request),
                    CancellationToken.None
                );

            Assert.Equal(HttpStatusCode.BadRequest, result.StatusCode);

            var responseContent = await result.Content.ReadAsStringAsync();
            Assert.Contains("This algorithm is not supported.", responseContent);
        }
    }
}
