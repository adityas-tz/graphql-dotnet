# GraphQL Weather Forecast API

This project has been converted from a REST API to a GraphQL API using HotChocolate and Banana Cake Pop.

## Features

- **GraphQL API** with HotChocolate framework
- **Banana Cake Pop IDE** for GraphQL exploration (available in development mode)
- **Weather Forecast Queries** with filtering, sorting, and projection support
- **Aspire.NET** integration for cloud-native development

## Getting Started

### Running the Application

```bash
cd graphql-dotnet
dotnet run
```

The application will start and be available at:
- **GraphQL Endpoint**: `https://localhost:{port}/graphql`
- **Banana Cake Pop IDE**: `https://localhost:{port}/graphql` (in development mode)

### GraphQL Queries

#### Get Weather Forecast (default 5 days)

```graphql
query GetWeatherForecast {
  weatherForecast {
    date
    temperatureC
    temperatureF
    summary
  }
}
```

#### Get Weather Forecast for Specific Number of Days

```graphql
query GetWeatherForecastWithDays {
  weatherForecast(days: 10) {
    date
    temperatureC
    temperatureF
    summary
  }
}
```

#### Get Weather Forecast for a Specific Date

```graphql
query GetWeatherForecastByDate {
  weatherForecastByDate(date: "2025-07-27") {
    date
    temperatureC
    temperatureF
    summary
  }
}
```

#### Using Filtering, Sorting, and Projections

```graphql
query GetFilteredWeatherForecast {
  weatherForecast(days: 10) 
  @filter(temperatureC: { gt: 20 })
  @orderBy([{ temperatureC: ASC }]) {
    date
    temperatureC
    summary
  }
}
```

## API Changes from REST

### Before (REST API)
- **Endpoint**: `GET /WeatherForecast`
- **Response**: JSON array of weather forecasts
- **Limited**: Fixed 5-day forecast only

### After (GraphQL API)
- **Endpoint**: `POST /graphql`
- **Response**: Structured GraphQL response
- **Flexible**: 
  - Query specific fields only
  - Variable number of days (1-30)
  - Query by specific date
  - Built-in filtering and sorting
  - Rich type system with descriptions

## Technologies Used

- **.NET 9.0**
- **HotChocolate** (GraphQL server)
- **Banana Cake Pop** (GraphQL IDE)
- **Aspire.NET** (Cloud-native development)

## Development

The GraphQL schema is automatically generated and can be explored using the Banana Cake Pop IDE available at the `/graphql` endpoint when running in development mode.
