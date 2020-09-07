using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorEditor.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.DependencyInjection;
using OrchardCore.Modules;

namespace BlazorEditor
{
    public class Startup : OrchardCore.Modules.StartupBase
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public override void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddSingleton<WeatherForecastService>();
        }

        public override void Configure(IApplicationBuilder builder, IEndpointRouteBuilder routes, IServiceProvider serviceProvider)
        {
            builder.UseStaticFiles();

            builder.UseRouting();

            routes.MapBlazorHub();
            routes.MapFallbackToPage("/_Host");
        }
    }
}
