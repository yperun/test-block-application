using Newtonsoft.Json;
using TestApplication.Helpers;

namespace TestApplication.DataModels;

[JsonConverter(typeof(BlockModelConverter))]
public abstract class BlockModel
{
    public string Id { get; set; }
    public int Order { get; set; }
}
