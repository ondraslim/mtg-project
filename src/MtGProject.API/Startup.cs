using DAL.EntityFramework.Data;
using GraphQL.API.Mutations;
using GraphQL.API.Queries;
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
            services.AddDbContext<MtgDbContext>(options => options.UseSqlServer(connectionString));

            services.AddGraphQL(SchemaBuilder.New()
                    .AddQueryType<Query>()
                    .AddMutationType<UserMutation>()
                // .AddType<UserType>()
                // .AddMutationType<MutationType>()
                // .AddSubscriptionType<SubscriptionType>()
                // .AddType<HumanType>()
                // .AddType<DroidType>()
                // .AddType<EpisodeType>()
                // .Create()
            );
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
                    await context.Response.WriteAsync("Hello World!");
                });
            });
        }
    }
}
