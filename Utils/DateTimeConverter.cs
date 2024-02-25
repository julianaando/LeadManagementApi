namespace LeadManagementApi.Utils;

using Newtonsoft.Json;

public class DateTimeConverter : JsonConverter<DateTime>
{
    public override DateTime ReadJson(JsonReader reader, Type objectType, DateTime existingValue, bool hasExistingValue, JsonSerializer serializer)
    {
        if (reader.Value == null)
        {
            return DateTime.MinValue;
        }
        if (DateTime.TryParse(reader.Value.ToString(), out DateTime result))
        {
            return result;
        }
        return DateTime.MinValue;
    }

    public override void WriteJson(JsonWriter writer, DateTime value, JsonSerializer serializer)
    {
        writer.WriteValue(value.ToString("dd/MM/yyyy HH:mm:ss"));
    }
}