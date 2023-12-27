namespace sorting_api_dotnet_core.API;

public class FileManager : IFileManager
{
    public async Task<string> ReadFileAsync(string fileName, CancellationToken ct)
    {
        if (File.Exists(fileName))
        {
            return await File.ReadAllTextAsync(fileName, ct);
        }
        else
        {
            throw new FileNotFoundException($"File '{fileName}' does not exist.");
        }
    }

    public Task WriteFileAsync(string fileName, string content, CancellationToken ct)
    {
        return File.WriteAllTextAsync(fileName, content, ct);
    }
}
