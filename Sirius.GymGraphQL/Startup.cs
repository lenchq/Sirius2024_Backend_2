using HotChocolate.AspNetCore;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Sirius.GymGraphQL.Database;
using Sirius.GymGraphQL.Interfaces;
using Sirius.GymGraphQL.Model;
using Sirius.GymGraphQL.Repository;
using Sirius.GymGraphQL.Types;
using Sirius.GymGraphQL.Types.InputType;

namespace Sirius.GymGraphQL;

internal sealed class Startup
{
    public IConfiguration Configuration;
    private readonly IWebHostEnvironment _env;

    public Startup(IConfiguration configuration, IWebHostEnvironment env)
    {
        Configuration = configuration;
        _env = env;
    }
    
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            // app.UseGraphiQL(new GraphiQLOptions {QueryPath = "/graphql", Path = "/graphiql"});
            app.UseDeveloperExceptionPage();
        }
        app.UseRouting();
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapGet("/", (ctx) =>
            {
                ctx.Response.Redirect("/graphql", true);
                return Task.FromResult(
                    new Microsoft.AspNetCore.Mvc.RedirectResult("/graphql", true));
            });
            endpoints.MapGraphQL().WithOptions(new GraphQLServerOptions
            {
                Tool = { Enable = true, GraphQLEndpoint = "/graphql", ServeMode = GraphQLToolServeMode.Latest},
            });
            // endpoints.MapGraphQLHttp();
            // endpoints.MapGraphQLSchema();
        });
    }

    public void ConfigureServices(IServiceCollection services)
    {
        services
            .AddGraphQLServer()
            .AddQueryType<QueryType>()
            .AddMutationType<MutationType>()
            .AddType<PurchaseType>()
            .AddType<CustomerType>()
            .AddType<GymType>()
            .AddType<TrainingType>()
            .AddTypes(typeof(AddTrainingInputType), typeof(AddGymInputType), typeof(AddCustomerInputType), typeof(PurchaseTrainingInputType),
                typeof(UpdateTrainingInputType), typeof(UpdateGymInputType), typeof(UpdateCustomerInputType))
            .ModifyRequestOptions(x =>
            {
                if (_env.IsDevelopment())
                {
                    x.IncludeExceptionDetails = true;
                }
            });

        var dbSettings = new SqliteConfiguration();
        Configuration.GetSection("SQLite").Bind(dbSettings);
        var connStr = new SqliteConnectionStringBuilder()
        {
            Mode = Enum.Parse<SqliteOpenMode>(dbSettings.Mode),
            DataSource = dbSettings.DataSource,

        }.ToString();
        
        services
            .AddDbContext<AppDbContext>(
                x => x.UseSqlite(connStr));

        services
            .AddScoped<ICustomerRepository, CustomerRepository>()
            .AddScoped<IGymRepository, GymRepository>()
            .AddScoped<IPurchaseRepository, PurchaseRepository>()
            .AddScoped<ITrainingRepository, TrainingRepository>();
        
        
        // var sqliteConf = new SqliteConfiguration();
        // Configuration.GetSection("SQLite").Bind(sqliteConf);
        // var connStr = new SqliteConnectionStringBuilder
        // {
        //     Mode = Enum.Parse<SqliteOpenMode>(sqliteConf.Mode),
        //     DataSource = sqliteConf.DataSource,
        //     Password = sqliteConf.Password,
        // }.ToString();
        //     
        // services.AddDbContext<AppDbContext>(
        //     options => options.UseSqlite(connStr));
        //
        // services
        //     .AddScoped<IDateTimeProvider, DateTimeProvider>()
        //     .AddScoped<ICaesarEncoder, CaesarEncoder>()
        //     .AddSingleton<IShiftRepository, ShiftRepository>()
        //     .AddSingleton<IRotStatisticsProvider, RotStatisticsProvider>()
        //     .AddControllers();
    }
}