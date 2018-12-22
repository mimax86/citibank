using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Citi.Service.Data;
using Citi.Service.Hubs;

namespace Citi.Service
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSignalR(opts => opts.EnableDetailedErrors = true);
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddSingleton<PositionService>();
            services.AddTransient<PositionSettings>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IApplicationLifetime lifetime)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSignalR(routes => { routes.MapHub<UpdateHub>("/update"); });

            app.UseMvc();

            lifetime.ApplicationStarted.Register(() =>
            {
                app.ApplicationServices.GetService<PositionService>().Start();
            });
        }
    }
}