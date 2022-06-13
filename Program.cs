using SqlQueryCreator.FileReaders;
using SqlQueryCreator.Services;



Console.WriteLine("Write your query json file available in TestData location");
var fileName = Console.ReadLine();

// Get and deserialize json 
var jsonData = JsonFileReader.FileReader($"{fileName}.json");
var data = JsonFileReader.DeserializeJson(jsonData);

// build sql query from json data
var sqlQueryService = new SqlQueryService();
var query = sqlQueryService.BuildSqlQuery(data);

Console.WriteLine(query);
