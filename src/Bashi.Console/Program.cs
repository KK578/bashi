// Copyright 2019-2020 (c) Bashi. All rights reserved.
// Licensed under the BSD-3-Clause license. See BSD-3-Clause.md for full details.

using System.Threading.Tasks;
using Bashi.Console.Application;
using McMaster.Extensions.CommandLineUtils;

namespace Bashi.Console
{
    /// <summary>
    /// Bashi Command Line Interface application entry point.
    /// </summary>
    internal static class Program
    {
        /// <summary>
        /// The application entry point method to run Bashi commands.
        /// </summary>
        /// <param name="args">Command line arguments.</param>
        /// <returns>A <see cref="Task"/> returning the program's exit code asynchronously.</returns>
        public static Task<int> Main(string[] args) => CommandLineApplication.ExecuteAsync<BashiCommandLineApplication>(args);
    }
}
