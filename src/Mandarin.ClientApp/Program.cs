// Copyright 2019-2019 (c) Bashi. All rights reserved.
// Licensed under the BSD-3-Clause license. See BSD-3-Clause.md for full details.

using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace Mandarin.ClientApp
{
    /// <summary>
    /// The Little Mandarin Client application entry point.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// Initialises the web host for The Little Mandarin Client application.
        /// </summary>
        /// <param name="args">Command line arguments.</param>
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        private static IHostBuilder CreateHostBuilder(string[] args)
            => Host.CreateDefaultBuilder(args)
                   .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
    }
}
