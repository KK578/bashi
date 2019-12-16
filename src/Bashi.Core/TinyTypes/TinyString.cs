// Copyright 2019-2019 (c) Bashi. All rights reserved.
// Licensed under the BSD-3-Clause license. See BSD-3-Clause.md for full details.

using System;

namespace Bashi.Core.TinyTypes
{
    /// <summary>
    /// TypeWrapper for a string value, to improve code clarity and add type safety.
    /// See <see cref="TinyType{T}"/>.
    ///
    /// Use <see cref="TinyString"/> for handling string comparisons, as it provides additional options for handling casing and culture options.
    /// </summary>
    public abstract class TinyString : TinyType<string>
    {
        private readonly StringComparer comparer;

        /// <summary>
        /// Initializes a new instance of the <see cref="TinyString"/> class.
        /// </summary>
        /// <param name="value">Given value for this instance.</param>
        /// <param name="comparer">Comparer to use for equality checks on the underlying string.</param>
        protected TinyString(string value, StringComparer? comparer = default)
            : base(value)
        {
            this.comparer = comparer ?? StringComparer.OrdinalIgnoreCase;
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            return this.comparer.GetHashCode(this.Value);
        }

        /// <inheritdoc />
        public override int CompareTo(TinyType<string> other)
        {
            return this.comparer.Compare(this.Value, other.Value);
        }

        /// <inheritdoc />
        protected override bool Equals(string other)
        {
            return this.comparer.Equals(this.Value, other);
        }
    }
}
