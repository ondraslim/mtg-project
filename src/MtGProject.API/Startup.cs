using DAL.EntityFramework.Data;
using GraphQL.API.Config;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

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
            services.AddControllers();

            services.AddCors();


            var connectionString = Configuration.GetConnectionString("db");
            services.AddDbContext<MtgDbContext>(options => options.UseSqlServer(connectionString), ServiceLifetime.Transient);
            services.AddSingleton(provider => new Func<DbContext>(provider.GetService<MtgDbContext>));

            //windsor registration of components
            var serviceResolver = new ServiceResolver(services);
            serviceResolver.GetServiceProvider();   // TODO: setup service provider
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
