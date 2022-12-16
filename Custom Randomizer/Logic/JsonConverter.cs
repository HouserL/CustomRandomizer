using System.Text.Json;
namespace CustomRandomizer.Logic;

public static class JsonConverter
{
    public static string ObjectToJson<T>(T jsonObject)
    {
        var convertString = JsonSerializer.Serialize(jsonObject, new JsonSerializerOptions { WriteIndented = true, });
        return convertString;
    }

    public static void WriteToFile<T>(T jsonObject, string filePath)
    {
        var toFile = ObjectToJson(jsonObject);
        File.WriteAllText(filePath, toFile);
        JsonSerializer.SerializeToDocument(jsonObject);
    }

    private static T FromJson<T>(string serialObject)
    {
        var output = JsonSerializer.Deserialize<T>(serialObject);
        return output;
    }

    public static T ReadJsonFile<T>(string filePath)
    {
        try
        {
            var loadedFile = FromJson<T>(File.ReadAllText(filePath));
            return loadedFile;
        }
        catch (Exception)
        {
            dynamic output = null;
            return output;
        }
    }
}
