var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.graphql_dotnet>("graphql-dotnet");

builder.Build().Run();
