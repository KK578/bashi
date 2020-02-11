// Copyright 2019-2020 (c) Bashi. All rights reserved.
// Licensed under the BSD-3-Clause license. See BSD-3-Clause.md for full details.

using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace Bashi.Identity.Server
{
    /// <summary>
    /// Bashi Identity Server application entry point.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// Main entry point for Bashi Identity Server.
        /// </summary>
        /// <param name="args">Command line arguments.</param>
        public static void Main(string[] args)
        {
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => webBuilder.UseStartup<Startup>())
                .Build()
                .Run();
        }
    }
}
