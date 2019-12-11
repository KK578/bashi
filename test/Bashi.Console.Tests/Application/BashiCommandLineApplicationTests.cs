// Copyright 2019-2019 (c) Bashi. All rights reserved.
// Licensed under the BSD-3-Clause license. See BSD-3-Clause.md for full details.

using System;
using System.IO;
using System.Threading.Tasks;
using Bashi.Console.Application;
using McMaster.Extensions.CommandLineUtils;
using McMaster.Extensions.CommandLineUtils.Abstractions;
using NUnit.Framework;

namespace Bashi.Console.Tests.Application
{
    [TestFixture]
    public class BashiCommandLineApplicationTests
    {
        [Test]
        public async Task CommandLine_GivenVersionFlag_ThenShouldDisplayApplicationVersion()
        {
            var arguments = this.CreateArguments("--version");
            var exitCode = await this.ExecuteAsync(arguments);
            Assert.That(exitCode, Is.Zero);
        }

        [Test]
        public async Task GivenAnAnimeDownloadCommand_ThenShouldDownloadToTheSpecifiedOutput()
        {
            var arguments = this.CreateArguments("anime", "download", "\"Shinchou Yuusha\"", "-s", "1", "-e", "1", "-o", "videos/");
            var exitCode = await this.ExecuteAsync(arguments);
            Assert.That(exitCode, Is.Zero);
            FileAssert.Exists("videos/Shinchou Yuusha/Shinchou Yuusha - S01E01.mp4");
        }

        private string[] CreateArguments(params string[] args) => args;

        private Task<int> ExecuteAsync(string[] arguments)
        {
            var commandLineContext = new TestCommandLineContext(arguments);
            return CommandLineApplication.ExecuteAsync<BashiCommandLineApplication>(arguments);
        }

        private class TestCommandLineContext : CommandLineContext
        {
            public TestCommandLineContext(string[] arguments)
            {
                this.Arguments = arguments;
                this.Console = new TestConsole();
            }
        }

        private class TestConsole : IConsole
        {
            public event ConsoleCancelEventHandler? CancelKeyPress
            {
                add { }
                remove { }
            }

            public TextWriter Out => TestContext.Progress;

            public TextWriter Error => TestContext.Error;

            public TextReader In => TextReader.Null;

            public bool IsInputRedirected => false;

            public bool IsOutputRedirected => false;

            public bool IsErrorRedirected => false;

            public ConsoleColor ForegroundColor { get; set; }

            public ConsoleColor BackgroundColor { get; set; }

            public void ResetColor()
            {
            }
        }
    }
}
