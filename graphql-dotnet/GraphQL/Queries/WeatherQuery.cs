using JetBrains.Annotations;

namespace graphql_dotnet.GraphQL.Queries;

/// <summary>
/// GraphQL Query root
/// </summary>
[PublicAPI]
[ExtendObjectType(OperationTypeNames.Query)]
public class WeatherQuery
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    /// <summary>
    /// Get weather forecast data
    /// </summary>
    /// <param name="logger">Logger instance</param>
    /// <param name="days">Number of days to forecast (default: 5)</param>
    /// <returns>Collection of weather forecasts</returns>
    public IEnumerable<WeatherForecast> GetWeatherForecast(
        [Service] ILogger<WeatherQuery> logger,
        int days = 5)
    {
        logger.LogInformation("Getting weather forecast for {Days} days at {Time}", days, DateTime.UtcNow);
        
        // Limit days to prevent excessive data
        days = Math.Max(1, Math.Min(days, 30));

        logger.LogDebug("Generating debug logs - weather forecast for {Days} days", days);

        return Enumerable.Range(1, days).Select(index => new WeatherForecast
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
    }

    /// <summary>
    /// Get weather forecast for a specific date
    /// </summary>
    /// <param name="logger">Logger instance</param>
    /// <param name="date">The date to get forecast for</param>
    /// <returns>Weather forecast for the specified date</returns>
    public WeatherForecast? GetWeatherForecastByDate(
        [Service] ILogger<WeatherQuery> logger,
        DateOnly date)
    {
        logger.LogInformation("Getting weather forecast for date {Date} at {Time}", date, DateTime.UtcNow);
        
        // Only provide forecasts for future dates within 30 days
        var today = DateOnly.FromDateTime(DateTime.Now);
        if (date <= today || date > today.AddDays(30))
        {
            return null;
        }

        return new WeatherForecast
        {
            Date = date,
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        };
    }
}
