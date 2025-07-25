namespace graphql_dotnet.GraphQL.Types;

/// <summary>
/// GraphQL type for WeatherForecast
/// </summary>
public class WeatherForecastType : ObjectType<WeatherForecast>
{
    protected override void Configure(IObjectTypeDescriptor<WeatherForecast> descriptor)
    {
        descriptor
            .Description("Represents a weather forecast for a specific date.");

        descriptor
            .Field(f => f.Date)
            .Description("The date of the weather forecast.");

        descriptor
            .Field(f => f.TemperatureC)
            .Description("Temperature in Celsius.");

        descriptor
            .Field(f => f.TemperatureF)
            .Description("Temperature in Fahrenheit.");

        descriptor
            .Field(f => f.Summary)
            .Description("A brief summary of the weather conditions.");
    }
}
