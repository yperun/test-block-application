namespace TestApplication.DataModels;

public class WebPageModel
{
    public string Key { get; set; }
    public IEnumerable<BlockModel> Blocks { get; set; }
}
