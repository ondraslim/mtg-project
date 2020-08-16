using DAL.EntityFramework.Data;
using GraphQL.Types.DataLoader;
using GraphQL.Types.Mutations;
using GraphQL.Types.Queries;
using HotChocolate;
using HotChocolate.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace GraphQL.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();

            var connectionString = Configuration.GetConnectionString("db");
            services.AddDbContext<MtgDbContext>(options => options.UseSqlServer(connectionString), ServiceLifetime.Transient);
            // TODO: uncomment when db context pooling with logging enabled
            //services.AddDbContextPool<MtgDbContext>(options => options.UseSqlServer(connectionString));

            services.AddGraphQL(SchemaBuilder.New()
                    .AddQueryType(d => d.Name("Queries"))
                        .AddType<Query>()
                    .AddMutationType(d => d.Name("Mutations"))
                        .AddType<UserMutation>()
                        .AddType<DeckMutation>()
                    //.EnableRelaySupport()
                    .Create()
            );

            services.AddDataLoader<UserByIdDataLoader>();
                // .AddType<UserType>()
                // .AddMutationType<MutationType>()
                // .AddSubscriptionType<SubscriptionType>()
                // .AddType<HumanType>()
                // .AddType<DroidType>()
                // .AddType<EpisodeType>()
                // .Create()
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseGraphQL();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World to My GraphQL experiment! Open me in Banana Cake Pop.");
                });
            });
        }
    }
}
