namespace sorting_api_dotnet_core.API;

public interface IFileManager
{
    Task<string> ReadFileAsync(string fileName, CancellationToken ct);

    Task WriteFileAsync(string fileName, string content, CancellationToken ct);
}
