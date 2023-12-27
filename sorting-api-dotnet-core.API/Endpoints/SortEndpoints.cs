using Microsoft.AspNetCore.Mvc;
using static sorting_api_dotnet_core.API.Configuration;
using static sorting_api_dotnet_core.API.Endpoints;

namespace sorting_api_dotnet_core.API;

public static class SortEndpoints
{
    public static WebApplication MapSortEndpoints(this WebApplication app)
    {
        var root = app.MapGroup(SORTING_GROUP).WithTags(SORTING_TAG).WithOpenApi();

        root.MapPost(SORT, Sort)
            .Produces<int[]>(StatusCodes.Status200OK)
            .AddEndpointFilter<ValidationFilter<SortRequest>>()
            .ProducesProblem(StatusCodes.Status500InternalServerError)
            .ProducesValidationProblem();

        root.MapGet(GET_LAST_SORTED_RESULT, GetLatestResult)
            .Produces<int[]>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status500InternalServerError);

        return app;
    }

    public static async Task<IResult> Sort(
        [FromBody] SortRequest request,
        IFileManager fileManager,
        Sorter sorter,
        CancellationToken cancellationToken
    )
    {
        try
        {
            sorter.Sort(request.Items, request.Algorithm);
            await fileManager.WriteFileAsync(
                DEFAULT_RESULT_FILE_NAME,
                string.Join(",", request.Items),
                cancellationToken
            );
            return Results.Ok(request.Items);
        }
        catch (Exception ex)
        {
            return Results.Problem(
                ex.StackTrace,
                ex.Message,
                StatusCodes.Status500InternalServerError
            );
        }
    }

    public static async Task<IResult> GetLatestResult(
        IFileManager fileManager,
        CancellationToken cancellationToken
    )
    {
        try
        {
            var result = await fileManager.ReadFileAsync(
                DEFAULT_RESULT_FILE_NAME,
                cancellationToken
            );
            var intArray = result.Split(',').Select(int.Parse).ToArray();
            return Results.Ok(intArray);
        }
        catch (Exception ex)
        {
            return Results.Problem(
                ex.StackTrace,
                ex.Message,
                StatusCodes.Status500InternalServerError
            );
        }
    }
}
