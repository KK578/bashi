// Copyright 2019-2019 (c) Bashi. All rights reserved.
// Licensed under the BSD-3-Clause license. See BSD-3-Clause.md for full details.

using System.Diagnostics;
using System.Reflection;
using Bashi.Console.Application.Anime;
using McMaster.Extensions.CommandLineUtils;

namespace Bashi.Console.Application
{
    /// <summary>
    /// Defines the Bashi command line application.
    /// </summary>
    [Subcommand(typeof(BashiAnimeCommand))]
    [Command("bashi", "A toolbox of assorted useful tools.")]
    [HelpOption]
    [VersionOptionFromMember(MemberName = nameof(Version))]
    internal sealed class BashiCommandLineApplication
    {
        /// <summary>
        /// Gets the version number for Bashi command line.
        /// </summary>
        public string Version => FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location).FileVersion;
    }
}
