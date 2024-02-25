namespace LeadManagementApi.Utils;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

public class EnumConverter : StringEnumConverter
{
    public override object ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
    {
        if (reader.TokenType == JsonToken.String && reader.Value != null)
        {
            string enumString = (string)reader.Value;
            if (Enum.TryParse(objectType, enumString, out var result))
            {
                return result;
            }
        }

        return base.ReadJson(reader, objectType, existingValue, serializer)!;
    }

    public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
    {
        if (value is Enum enumValue)
        {
            writer.WriteValue(enumValue.ToString("G"));
        }
        else
        {
            base.WriteJson(writer, value, serializer);
        }
    }
}