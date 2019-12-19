// Copyright 2019-2019 (c) Bashi. All rights reserved.
// Licensed under the BSD-3-Clause license. See BSD-3-Clause.md for full details.

using System.Threading.Tasks;
using NUnit.Framework;

namespace Bashi.Console.Tests.Application
{
    [TestFixture]
    public class ProgramEntryPointTests
    {
        [Test]
        public async Task CommandLine_GivenVersionFlag_ThenShouldDisplayApplicationVersion()
        {
            var arguments = new[] { "--version" };
            var exitCode = await Program.Main(arguments).ConfigureAwait(false);
            Assert.That(exitCode, Is.Zero);
        }
    }
}
