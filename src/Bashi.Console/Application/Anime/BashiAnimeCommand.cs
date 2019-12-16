// Copyright 2019-2019 (c) Bashi. All rights reserved.
// Licensed under the BSD-3-Clause license. See BSD-3-Clause.md for full details.

using McMaster.Extensions.CommandLineUtils;

namespace Bashi.Console.Application.Anime
{
    /// <summary>
    /// Defines operations for downloading/updating anime episodes and metadata.
    /// </summary>
    [Subcommand(typeof(BashiAnimeDownloadCommand))]
    [Command("anime", Description = "Tools for downloading/updating anime.")]
    internal sealed class BashiAnimeCommand
    {
    }
}
