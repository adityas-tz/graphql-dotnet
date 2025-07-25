namespace graphql_dotnet;

/// <summary>
/// Represents a weather forecast for a specific date
/// </summary>
public class WeatherForecast
{
    /// <summary>
    /// The date of the weather forecast
    /// </summary>
    public DateOnly Date { get; set; }

    /// <summary>
    /// Temperature in Celsius
    /// </summary>
    public int TemperatureC { get; set; }

    /// <summary>
    /// Temperature in Fahrenheit (calculated from Celsius)
    /// </summary>
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

    /// <summary>
    /// A brief summary of the weather conditions
    /// </summary>
    public string? Summary { get; set; }
}
