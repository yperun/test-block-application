using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using TestApplication.DataModels;

namespace TestApplication.Helpers;

public class BlockModelConverter : JsonConverter
{
    private static readonly JsonSerializerSettings CustomConversion = new()
        { ContractResolver = new BlockModelContractResolver() };

    public override bool CanWrite => false;

    public override bool CanConvert(Type objectType)
    {
        return objectType == typeof(BlockModel);
    }

    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    {
        var jObject = JObject.Load(reader);
        switch (jObject["Id"].Value<string>())
        {
            case Constants.HeaderBlockId:
                return JsonConvert.DeserializeObject<HeaderBlockModel>(jObject.ToString(), CustomConversion);
            case Constants.HeroBlockId:
                return JsonConvert.DeserializeObject<HeroBlockModel>(jObject.ToString(), CustomConversion);
            case Constants.ServicesBlockId:
                return JsonConvert.DeserializeObject<ServicesBlockModel>(jObject.ToString(), CustomConversion);
            default:
                throw new NotImplementedException();
        }
    }

    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    {
        throw new NotImplementedException();
    }
}
