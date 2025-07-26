using graphql_dotnet;
using HotChocolate.Execution;
using Serilog;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
builder.AddServiceDefaults();

builder.Services.AddCors();
builder.Services.ConfigureServices(builder.Configuration, builder.Environment);


WebApplication app = builder.Build();
app.ConfigureEndpointRouteBuilder();

app.UseCors(corsPolicyBuilder =>
{
    corsPolicyBuilder
        .AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader();
});
var resolver = ActivatorUtilities.GetServiceOrCreateInstance<IRequestExecutorResolver>(app.Services);

IRequestExecutor executor = resolver.GetRequestExecutorAsync("GraphqlDotNet").AsTask().Result;
var schema = executor.Schema.ToString();
File.WriteAllText("GraphqlDotNet.graphql", schema);
app.UseExceptionHandler("/Error");
// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
app.UseHsts();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();
app.MapDefaultEndpoints();
app.UseRouting();

app.Run();
