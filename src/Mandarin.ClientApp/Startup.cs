// Copyright 2019-2019 (c) Bashi. All rights reserved.
// Licensed under the BSD-3-Clause license. See BSD-3-Clause.md for full details.

using System.Diagnostics.CodeAnalysis;
using Mandarin.ClientApp.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Mandarin.ClientApp
{
    /// <summary>
    /// Configures The Little Mandarin's Client application services and HTTP pipeline.
    /// </summary>
    [SuppressMessage("ReSharper", "CA1822", Justification = "Startup is instantiated by the framework.")]
    public class Startup
    {
        private readonly IConfiguration configuration;

        /// <summary>
        /// Initializes a new instance of the <see cref="Startup"/> class.
        /// </summary>
        /// <param name="configuration">Application configuration to be used.</param>
        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        /// <summary>
        /// Adds application services into the IoC container.
        /// This method gets called by the ASP.NET Core runtime.
        /// </summary>
        /// <param name="services">Service collection to be configured.</param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddSingleton<WeatherForecastService>();
        }

        /// <summary>
        /// Configures the HTTP request pipeline.
        /// This method gets called by the ASP.NET Core runtime.
        /// </summary>
        /// <param name="app">Application instance to configure.</param>
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            IWebHostEnvironment env = app.ApplicationServices.GetService<IWebHostEnvironment>();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
