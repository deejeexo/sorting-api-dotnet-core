namespace sorting_api_dotnet_core.API.Tests
{
    public class FileManagerTests
    {
        [Fact]
        public async Task ReadFileAsync_ExistingFile_ReturnsFileContent()
        {
            var fileName = "test.txt";
            var fileContent = "Hello, World!";
            File.WriteAllText(fileName, fileContent);
            var fileManager = new FileManager();

            var result = await fileManager.ReadFileAsync(fileName, CancellationToken.None);

            Assert.Equal(fileContent, result);
        }

        [Fact]
        public async Task ReadFileAsync_NonExistingFile_ThrowsFileNotFoundException()
        {
            var fileName = "nonexisting.txt";
            var fileManager = new FileManager();

            await Assert.ThrowsAsync<FileNotFoundException>(
                () => fileManager.ReadFileAsync(fileName, CancellationToken.None)
            );
        }

        [Fact]
        public async Task WriteFileAsync_WritesContentToFile()
        {
            var fileName = "test.txt";
            var fileContent = "Hello, World!";
            var fileManager = new FileManager();

            await fileManager.WriteFileAsync(fileName, fileContent, CancellationToken.None);

            Assert.Equal(fileContent, File.ReadAllText(fileName));
        }
    }
}
