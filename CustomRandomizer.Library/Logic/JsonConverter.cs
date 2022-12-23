using System.Text.Json;

namespace CustomRandomizer.Library.Logic;

public static class JsonConverter
{
    public static string ObjectToJson<T>(T jsonObject)
    {
        return JsonSerializer.Serialize(jsonObject, new JsonSerializerOptions { WriteIndented = true, });
    }
    public static void WriteToFile<T>(T jsonObject, string filePath)
    {
        var toFile = ObjectToJson(jsonObject);
        File.WriteAllText(filePath, toFile);
        JsonSerializer.SerializeToDocument(jsonObject);
    }
    private static T FromJson<T>(string serialObject)
    {
        return JsonSerializer.Deserialize<T>(serialObject);
    }
    public static T ReadJsonFile<T>(string filePath) where T : class, new()
    {
        try
        {
            return FromJson<T>(File.ReadAllText(filePath));
        }
        catch (Exception)
        {
            return new T();
        }
    }
}
