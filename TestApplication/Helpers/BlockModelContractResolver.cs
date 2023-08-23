using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using TestApplication.DataModels;

namespace TestApplication.Helpers;

public class BlockModelContractResolver : DefaultContractResolver
{
    protected override JsonConverter ResolveContractConverter(Type objectType)
    {
        if (typeof(BlockModel).IsAssignableFrom(objectType) && !objectType.IsAbstract)
            return null;
        return base.ResolveContractConverter(objectType);
    }
}
