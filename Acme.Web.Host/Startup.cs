using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Acme.Web.Host.Models;

namespace Acme.Web.Host
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }


        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.Configure<AcmeSettings>(Configuration.GetSection("AcmeSettings"));
        }


        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            // Important so all of our angular app files can be used that
            // get deployed to the wwwroot folder
            app.UseStaticFiles();
            
            app.UseMvc(routes =>
            {
                routes.MapRoute("default", "{controller}/{action}");
                
                // This will ensure all of our client side angular app traffic routes through our 
                // client application
                routes.MapRoute("App", "{*url}", defaults: new { controller = "Home", action = "App" });
            });
        }
    }
}
