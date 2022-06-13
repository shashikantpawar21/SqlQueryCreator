using Newtonsoft.Json;
using SqlQueryCreator.Models;

namespace SqlQueryCreator.FileReaders;
public class JsonFileReader
{

    private static readonly string _basePath = Path.Combine(Directory.GetCurrentDirectory(), fileLocation);

    private const string fileLocation = "TestData";

    public static string FileReader(string fileName)
    {
        try
        {
            var filePath = Path.Combine(_basePath, fileName);
            var jsonData = File.ReadAllText(filePath);
            return jsonData;
        }
        catch (FileNotFoundException fn)
        {
            Console.WriteLine($"File Not Found. File name : {fn.FileName}");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        return string.Empty;
    }
    public static Data DeserializeJson(string jsonData)
    {
        return JsonConvert.DeserializeObject<Data>(jsonData);
    }

}