// Copyright 2019-2019 (c) Bashi. All rights reserved.
// Licensed under the BSD-3-Clause license. See BSD-3-Clause.md for full details.

using AutoFixture;

namespace Bashi.Tests.Framework.Data
{
    public static class TestData
    {
        private static readonly Fixture Fixture;

        static TestData()
        {
            Fixture = new Fixture();
            WellKnownInt = NextInt();
            WellKnownString = NextString();
        }

        public static int WellKnownInt { get; }

        public static string WellKnownString { get; }

        public static int NextInt()
        {
            return Fixture.Create<int>();
        }

        public static string NextString()
        {
            return Fixture.Create<string>();
        }
    }
}
