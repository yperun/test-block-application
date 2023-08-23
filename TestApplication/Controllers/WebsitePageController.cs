using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TestApplication.Services;

namespace TestApplication.Controllers;

[Route("api/webpage")]
public class WebsitePageController : Controller
{
    private readonly PersistenceService _persistenceService;

    public WebsitePageController(PersistenceService persistenceService)
    {
        _persistenceService = persistenceService;
    }

    [HttpPost]
    [Route("create")]
    public async Task<IActionResult> Create([FromQuery] [Required] string key)
    {
        var createdWebPage = await _persistenceService.CreateNewWebPage(key);
        return Ok(JsonConvert.SerializeObject(createdWebPage));
    }

    [HttpGet]
    [Route("retrieve")]
    public async Task<IActionResult> Retrieve([FromQuery] [Required] string key)
    {
        var retrievedPage = await _persistenceService.ReadWebPage(key);
        return Ok(JsonConvert.SerializeObject(retrievedPage));
    }

    [HttpPut]
    [Route("update")]
    public async Task<IActionResult> Update(
        [FromQuery] [Required] string key,
        [FromQuery] [Required] string blockId,
        [FromBody] [Required] object newBlockJson)
    {
        var modifiedWebPage = await _persistenceService.Update(key, blockId, newBlockJson.ToString());
        return Ok(JsonConvert.SerializeObject(modifiedWebPage));
    }

    [HttpDelete]
    [Route("remove")]
    public async Task<IActionResult> Remove([FromQuery] [Required] string key, [FromQuery] [Required] string blockId)
    {
        var modifiedWebPage = await _persistenceService.RemoveBlock(key, blockId);
        return Ok(JsonConvert.SerializeObject(modifiedWebPage));
    }
}
