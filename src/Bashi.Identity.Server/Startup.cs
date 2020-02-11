// Copyright 2019-2020 (c) Bashi. All rights reserved.
// Licensed under the BSD-3-Clause license. See BSD-3-Clause.md for full details.

using System.Diagnostics.CodeAnalysis;
using IdentityServer4.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Bashi.Identity.Server
{
    /// <summary>
    /// Startup configuration for Bashi Identity Server.
    /// </summary>
    [SuppressMessage("FxCop", "CA1812", Justification = "Used by HostBuilder.")]
    internal class Startup
    {
        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940.
        /// </summary>
        /// <param name="services">Service collection to be configured.</param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddIdentityServer()
                    .AddDeveloperSigningCredential()
                    .AddInMemoryClients(new[]
                    {
                        new Client
                        {
                            ClientId = "KtD the Client",
                            AllowedGrantTypes = GrantTypes.ClientCredentials,
                            ClientSecrets =
                            {
                                new Secret("Honk".Sha256(), "Goose"),
                            },
                            AllowedScopes =
                            {
                                "Zoo",
                            },
                        },
                    })
                    .AddInMemoryApiResources(new[]
                    {
                        new ApiResource("Zoo", "A fabulous place for honking."),
                    });

            services.AddAuthentication()
                    .AddIdentityServerAuthentication(options =>
                    {
                        options.Authority = "http://localhost:5000";
                        options.RequireHttpsMetadata = false;

                        options.ApiName = "Zoo";
                    });
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app">Application to be configured.</param>
        public void Configure(IApplicationBuilder app)
        {
            var env = app.ApplicationServices.GetService<IWebHostEnvironment>();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseIdentityServer();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}");
            });
        }
    }
}
