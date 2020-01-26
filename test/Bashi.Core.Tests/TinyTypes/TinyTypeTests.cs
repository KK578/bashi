// Copyright 2019-2020 (c) Bashi. All rights reserved.
// Licensed under the BSD-3-Clause license. See BSD-3-Clause.md for full details.

using System.Diagnostics.CodeAnalysis;
using Bashi.Core.TinyTypes;
using Bashi.Tests.Framework.Data;
using NUnit.Framework;

namespace Bashi.Core.Tests.TinyTypes
{
    [TestFixture]
    [SuppressMessage("ReSharper", "SuspiciousTypeConversion.Global", Justification = "Verifying equalities")]
    [SuppressMessage("ReSharper", "RedundantCast", Justification = "Verifying specific equalities")]
    public class TinyTypeTests
    {
        [Test]
        public void ImplicitOperatorToUnderlying_ShouldAutomaticallyConvertValues()
        {
            var tt = new MyNumber(TestData.WellKnownInt);
            int value = tt;
            Assert.That(tt.Value, Is.EqualTo(value));
            Assert.That(value, Is.EqualTo(TestData.WellKnownInt));
        }

        [Test]
        public void Equals_GivenANonMatchingTypeAndValue_ThenTheyAreNotEqual()
        {
            var tt = new MyNumber(TestData.WellKnownInt);

            Assert.That(tt.Equals(TestData.WellKnownInt), Is.False);
            Assert.That(tt.Equals((double)TestData.WellKnownInt), Is.False);
            Assert.That(tt.Equals((object?)null), Is.False);
        }

        [Test]
        public void Equals_GivenAMatchingType_WhenValuesDoNotMatch_ThenTheyAreNotEqual()
        {
            var tt = new MyNumber(TestData.WellKnownInt);

            var differentInt = TestData.NextInt();
            Assert.That(tt.Equals(new MyNumber(differentInt)), Is.False);
            Assert.That(tt == new MyNumber(differentInt), Is.False);
            Assert.That(tt != new MyNumber(differentInt), Is.True);
            Assert.That(tt.Equals((MyNumber?)null), Is.False);
        }

        [Test]
        public void Equals_GivenAMatchingType_WhenValuesDoNotMatch_ThenTheyAreEqual()
        {
            var tt = new MyNumber(TestData.WellKnownInt);

            Assert.That(tt.Equals(tt), Is.True);
            Assert.That(tt.Equals((object)tt), Is.True);
            Assert.That(tt.Equals(new MyNumber(TestData.WellKnownInt)), Is.True);
            Assert.That(tt.Equals(new MyNumber(TestData.WellKnownInt) as object), Is.True);
            Assert.That(tt == new MyNumber(TestData.WellKnownInt), Is.True);
        }

        [Test]
        public void GetHashCode_MatchesUnderlyingValueHashCode()
        {
            var tt = new MyNumber(TestData.WellKnownInt);
            Assert.That(tt.GetHashCode(), Is.EqualTo(TestData.WellKnownInt.GetHashCode()));
        }

        [Test]
        public void CompareTo_GivenNullOrNonMatchingTypes_ThenWillThrowException()
        {
            var tt = new MyNumber(TestData.WellKnownInt);

            Assert.That(() => tt.CompareTo((object?)null), Throws.ArgumentNullException);
            Assert.That(() => tt.CompareTo((MyNumber?)null), Throws.ArgumentNullException);
            Assert.That(() => tt.CompareTo(TestData.WellKnownInt), Throws.ArgumentException);
            Assert.That(() => tt.CompareTo(TestData.WellKnownString), Throws.ArgumentException);
        }

        [Test]
        public void CompareTo_GivenMatchingTypes_ThenWillCompareByUnderlying()
        {
            var tt = new MyNumber(TestData.WellKnownInt);
            var value = TestData.NextInt();

            Assert.That(tt.CompareTo(new MyNumber(value)), Is.EqualTo(TestData.WellKnownInt.CompareTo(value)));
            Assert.That(tt.CompareTo(new MyNumber(TestData.WellKnownInt)), Is.Zero);
            Assert.That(tt.CompareTo((object)tt), Is.Zero);
            Assert.That(tt.CompareTo(tt), Is.Zero);
        }

        private class MyNumber : TinyType<int>
        {
            public MyNumber(int value)
                : base(value)
            {
            }
        }
    }
}
