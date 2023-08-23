namespace TestApplication.Services;

public class FileService
{
    public async Task CreateFile(string fileName, string fileContent)
    {
        CreateDirectoryIfDoesNotExist();
        await File.WriteAllTextAsync(GetFilePath(fileName), fileContent);
        Console.WriteLine($"Successfully written to {GetFilePath(fileName)}!");
    }

    public async Task<string> ReadFile(string fileName)
    {
        var fileContent = await File.ReadAllTextAsync(GetFilePath(fileName));
        Console.WriteLine($"Successfully read from {GetFilePath(fileName)}!");
        return fileContent;
    }

    private void CreateDirectoryIfDoesNotExist()
    {
        if (!Directory.Exists(Constants.FilePersistencePath))
            Directory.CreateDirectory(Constants.FilePersistencePath);
    }

    private string GetFilePath(string fileName)
    {
        return Path.Combine(Constants.FilePersistencePath, fileName);
    }
}
