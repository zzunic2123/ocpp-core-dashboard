using Utf8Json;

namespace CPMS.Shared.JsonFormatters.Proxy;

// this is because ABB charger sends null as string "null" instead of null
public class NullStringJsonFormatter : IJsonFormatter<string>
{
    public void Serialize(ref JsonWriter writer, string value, IJsonFormatterResolver formatterResolver)
    {
        writer.WriteString(value);
    }

    public string Deserialize(ref JsonReader reader, IJsonFormatterResolver formatterResolver)
    {
        if (reader.GetCurrentJsonToken() == JsonToken.String)
        {
            var value = reader.ReadString();
            if (value == "null")
            {
                return null;
            }
            return value;
        }
        return null;
    }
}
