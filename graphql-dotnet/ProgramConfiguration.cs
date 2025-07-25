using graphql_dotnet.Constants;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Serilog;

namespace graphql_dotnet
{
    internal static partial class ProgramConfiguration
    {
        private const string Live = "live";
        private const string Ready = "ready";
        internal static void ConfigureServices(this IServiceCollection services, IConfiguration configuration, IWebHostEnvironment environment)
        {
            //var conn = configuration.GetConnectionString("DefaultConnection");
            services.AddGraphQl(configuration);


            //services.AddDbContext<GraphqlDbContext>(options =>
            //    options.UseNpgsql(conn));

            //DI
            //services.AddScoped<IGraphqlRepository, GraphqlRepository>();
        }

        internal static void ConfigureHostBuilder(this IHostBuilder builder)
        {
            builder.UseSerilog(LoggingConfiguration);
            //builder.ConfigureHostConfiguration(HostConfiguration);
        }

        private static void LoggingConfiguration(HostBuilderContext context, IServiceProvider provider, LoggerConfiguration loggerConfiguration)
        {
            loggerConfiguration
                .ReadFrom.Configuration(context.Configuration)
                .ReadFrom.Services(provider);
        }

        internal static void ConfigureEndpointRouteBuilder(this IEndpointRouteBuilder app)
        {
            app.MapGraphQL(EndPoints.API, schemaName: SchemaNames.GraphqlDotNet);
        }
    }
}
