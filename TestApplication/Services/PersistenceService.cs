using Newtonsoft.Json;
using TestApplication.DataModels;

namespace TestApplication.Services;

public class PersistenceService
{
    private const string BlockFileNamePrefix = "block-";
    private const string BlockFileNameExtension = ".json";
    private readonly FileService _fileService;

    public PersistenceService(FileService fileService)
    {
        _fileService = fileService;
    }


    public async Task<WebPageModel> CreateNewWebPage(string key)
    {
        if (_fileService.FileExists(GetBlockNameByKey(key)))
        {
            throw new Exception("A web page with this name already exists!");
        }
        var defaultWebPageContent = await _fileService.ReadFile(Constants.DefaultWebsitePageFileName);
        var newWebPage = JsonConvert.DeserializeObject<WebPageModel>(defaultWebPageContent);
        newWebPage.Key = key;
        return await SaveWebPage(newWebPage);
    }

    public async Task<WebPageModel> SaveWebPage(WebPageModel webPage)
    {
        var webPageJson = JsonConvert.SerializeObject(webPage);
        await _fileService.CreateFile(GetBlockNameByKey(webPage.Key), webPageJson);
        return await ReadWebPage(webPage.Key);
    }

    public async Task<WebPageModel> ReadWebPage(string key)
    {
        var websiteText = await _fileService.ReadFile(GetBlockNameByKey(key));
        var websiteObject = JsonConvert.DeserializeObject<WebPageModel>(websiteText);
        return websiteObject;
    }

    public async Task<WebPageModel> Update(string key, string blockId, string blockModelJson)
    {
        var webPage = await ReadWebPage(key);
        webPage.Blocks = webPage.Blocks.Where(block => block.Id != blockId);
        var updatedSection = JsonConvert.DeserializeObject<BlockModel>(blockModelJson);
        updatedSection.Id = blockId;
        webPage.Blocks = webPage.Blocks.Append(updatedSection);
        await SaveWebPage(webPage);
        return webPage;
    }

    public async Task<WebPageModel> RemoveBlock(string key, string blockId)
    {
        var webPage = await ReadWebPage(key);
        var blockCountBeforeRemoval = webPage.Blocks.Count();
        webPage.Blocks = webPage.Blocks.Where(block => block.Id != blockId);
        var blockCountAfterRemoval = webPage.Blocks.Count();
        if (blockCountBeforeRemoval - blockCountAfterRemoval != 1)
        {
            throw new Exception($"Tried to remove an incorrect number of blocks ({blockCountBeforeRemoval - blockCountAfterRemoval}). Removal canceled.");
        }
        webPage.Blocks = webPage.Blocks.Where(block => block.Id != blockId);
        await SaveWebPage(webPage);
        return webPage;
    }

    private string GetBlockNameByKey(string key)
    {
        return string.Concat(BlockFileNamePrefix, key, BlockFileNameExtension);
    }
}
