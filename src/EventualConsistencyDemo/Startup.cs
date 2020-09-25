using EventualConsistencyDemo.Hubs;
using LiteDB;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NServiceBus;
using NServiceBus.Hosting.Helpers;
using Shared.Configuration;
using Shared.Hubs;

namespace EventualConsistencyDemo
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
            // We're using NServiceBus anyway, so let's use it to scan all assemblies.
            var assemblyScannerResults = new AssemblyScanner().GetScannableAssemblies();

            services.AddControllersWithViews();

            services.AddSignalR();

            services.AddScoped(_ => new LiteRepository(Database.DatabaseConnectionstring));

            services.AddMediatR(assemblyScannerResults.Assemblies.ToArray());

            // services.AddMemoryCache();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHub<TicketHub>("/ticketHub");

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}");

                endpoints.MapControllerRoute(
                    name: "movie",
                    pattern: "{controller}/{movieurl}", 
                    defaults: new { controller = "Movies", action = "Movie" });
            });
        }
    }
}
