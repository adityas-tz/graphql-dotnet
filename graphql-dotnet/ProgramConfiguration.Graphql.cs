using graphql_dotnet.Constants;
using graphql_dotnet.GraphQL.Queries;
using graphql_dotnet.GraphQL.Types;
using HotChocolate.Execution.Configuration;
using HotChocolate.Execution.Options;
using System.Diagnostics.CodeAnalysis;

namespace graphql_dotnet
{
    [SuppressMessage("ReSharper", "UnusedMethodReturnValue.Local")]
    internal partial class ProgramConfiguration
    {
        private static void ConfigureSchemaOptions(SchemaOptions options)
        {
            options.SortFieldsByName = true;
            options.EnableFlagEnums = true;
            options.RemoveUnreachableTypes = true;
        }
        private static void AddGraphQl(this IServiceCollection services, IConfiguration configuration)
        {
            services.ResolveQueriesDependency();
            services.ResolveMutationsDependency();

            services.AddGraphQLServer(SchemaNames.GraphqlDotNet)
                //.AddCommonConfig()
                //.AddWeatherForecastTypes()
                .AddAllQueries()
                //.AddAllMutation()
                .InitializeOnStartup();
        }

        private static void ResolveMutationsDependency(this IServiceCollection services)
        {
            //services.AddScoped<GraphqlMutation>();
        }
        private static void ResolveQueriesDependency(this IServiceCollection services)
        {
            services.AddScoped<WeatherQuery>();
        }
        private static IRequestExecutorBuilder AddWeatherForecastTypes(this IRequestExecutorBuilder builder)
        {
            return builder
                .AddType<WeatherForecastType>();
        }

        //private static IRequestExecutorBuilder AddCommonConfig(this IRequestExecutorBuilder builder)
        //{
        //    return builder.ModifyOptions(ConfigureSchemaOptions)
        //        .AddGlobalObjectIdentification()
        //        .AddQueryFieldToMutationPayloads()
                //.ModifyRequestOptions(ConfigureRequestExecutorOptions)
                //.AddSorting()
                //.AddProjections()
                //.AddFiltering()
                //.AddErrorFilter<DetailRemovingErrorFilter>()
                //.AllowIntrospection(true);
                //.AddInstrumentation(ConfigureInstrumentation);
            //.AddDiagnosticEventListener<QueryLogger>();
        //}
        //private static void ConfigureRequestExecutorOptions(IServiceProvider provider, RequestExecutorOptions options)
        //{
        //    options.IncludeExceptionDetails = true;
        //    options.Complexity.Enable = true;
        //    options.Complexity.ApplyDefaults = true;

        //    options.Complexity.Calculation = ComplexityCalculator;
        //}

        //private static int ComplexityCalculator(ComplexityContext context)
        //{
        //    int cost = context.Complexity + context.ChildComplexity;

        //    //Log.Debug(ProgramConfiguration.MessageTemplate, $"Cost: {context.Selection.Name} {cost}");

        //    return cost;
        //}

        private static IRequestExecutorBuilder AddAllQueries(this IRequestExecutorBuilder builder)
        {
            return builder
                .AddQueryType(descriptor => descriptor.Name(OperationTypeNames.Query))
                .AddTypeExtension<WeatherQuery>();
                //.AddTypeExtension<xyzquery>()
        }
        private static IRequestExecutorBuilder AddAllMutation(this IRequestExecutorBuilder builder)
        {
            return builder
                .AddMutationType(descriptor => descriptor.Name(OperationTypeNames.Mutation));
            //.AddTypeExtension<xyzmutation>();
        }


    }
}
