using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Citi.Service.Data;
using Citi.Service.Data.Positions;
using Citi.Service.Data.Prices;
using Citi.Service.Hubs;
using Citi.Service.Timing;

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
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", p =>
                {
                    p.AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
            });
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddTransient<ITimerFactory, TimerFactory>();
            services.AddSingleton<SpotService>();
            services.AddSingleton<PositionService>();
            services.AddTransient<DataGenerationSettings>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IApplicationLifetime lifetime)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSignalR(routes => { routes.MapHub<UpdateHub>("/update"); });

            app.UseCors("AllowAll");

            app.UseMvc();

            lifetime.ApplicationStarted.Register(() =>
            {
                app.ApplicationServices.GetService<PositionService>().Start();
            });
        }
    }
}