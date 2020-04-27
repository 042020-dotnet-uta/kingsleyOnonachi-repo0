using System.Text.Json;
using System.Text.Json.Serialization;

public class SerialerExample{
    string jsonString;
    jsonString = JsonSerializer.Serialize(weatherForecast);
    //creating a file using a synchronous
    File.WriteAllText(fileName, jsonString);

        //using asynchronous code to create a JSON file:
    using (FileStream fs = File.Create(fileName))
    {
        await JsonSerializer.SerializeAsync(fs, weatherForecast);
    }

    //use type inference for the type being serialized. An overload of Serialize() takes a generic type parameter:
    jsonString = JsonSerializer.Serialize<WeatherForecastWithPOCOs>(weatherForecast);

    
}
public class WeatherForecastWithPOCOs
{
    public DateTimeOffset Date { get; set; }
    public int TemperatureCelsius { get; set; }
    public string Summary { get; set; }
    public string SummaryField;
    public IList<DateTimeOffset> DatesAvailable { get; set; }
    public Dictionary<string, HighLowTemps> TemperatureRanges { get; set; }
    public string[] SummaryWords { get; set; }
}

public class HighLowTemps
{
    public int High { get; set; }
    public int Low { get; set; }
}