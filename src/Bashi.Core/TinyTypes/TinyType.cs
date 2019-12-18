// Copyright 2019-2019 (c) Bashi. All rights reserved.
// Licensed under the BSD-3-Clause license. See BSD-3-Clause.md for full details.

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Bashi.Core.TinyTypes
{
    /// <summary>
    /// TypeWrapper for any value, to improve code clarity and add type safety.
    ///
    /// A TinyType is most useful for a primitive value which may not be known at compile time,
    /// but is known to have special meaning.
    /// For example, a DatabaseId or CategoryName.
    ///
    /// This implementation also provides implicit conversion from a <see cref="TinyType{T}"/> to
    /// the wrapped <typeparamref name="T"/> type.
    /// </summary>
    /// <typeparam name="T">Underlying value type.</typeparam>
    public abstract class TinyType<T> : IEquatable<TinyType<T>>, IComparable<TinyType<T>>, IComparable
        where T : notnull, IComparable<T>, IComparable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TinyType{T}"/> class.
        /// </summary>
        /// <param name="value">Given value for this instance.</param>
        protected TinyType(T value)
        {
            this.Value = value;
        }

        /// <summary>
        /// Gets the underlying value.
        /// </summary>
        public T Value { get; }

        /// <summary>
        /// Implicitly casts a <see cref="TinyType{T}"/> into the underlying <typeparamref name="T"/>.
        /// </summary>
        /// <param name="arg">The instance of the TinyType.</param>
        /// <returns>Returns <see cref="Value"/>.</returns>
        [SuppressMessage("ReSharper", "CA2225", Justification = "Operator is a shorthand for accessing the Value property.")]
        public static implicit operator T(TinyType<T> arg) => arg.Value;

        /// <summary>
        /// Overriding operator for equality check between two <see cref="TinyType{T}"/> instances.
        /// </summary>
        /// <param name="left">First instance to be compared.</param>
        /// <param name="right">Second instance to be compared.</param>
        /// <returns>Indicates whether the two instances are equal.</returns>
        public static bool operator ==(TinyType<T>? left, TinyType<T>? right)
        {
            return !ReferenceEquals(left, null) && left.Equals(right);
        }

        /// <summary>
        /// Overriding operator for inequality check between two <see cref="TinyType{T}"/> instances.
        /// </summary>
        /// <param name="left">First instance to be compared.</param>
        /// <param name="right">Second instance to be compared.</param>
        /// <returns>Indicates whether the two instances are not equal.</returns>
        public static bool operator !=(TinyType<T>? left, TinyType<T>? right)
        {
            return !(left == right);
        }

        /// <summary>
        /// Overriding operator for less than check between two <see cref="TinyType{T}"/> instances.
        /// </summary>
        /// <param name="left">First instance to be compared.</param>
        /// <param name="right">Second instance to be compared.</param>
        /// <returns>Indicates whether the left instance is less than the right instance.</returns>
        public static bool operator <(TinyType<T> left, TinyType<T> right)
        {
            return ReferenceEquals(left, null) ? !ReferenceEquals(right, null) : left.CompareTo(right) < 0;
        }

        /// <summary>
        /// Overriding operator for less than or equal to check between two <see cref="TinyType{T}"/> instances.
        /// </summary>
        /// <param name="left">First instance to be compared.</param>
        /// <param name="right">Second instance to be compared.</param>
        /// <returns>Indicates whether the left instance is less than or equal to the right instance.</returns>
        public static bool operator <=(TinyType<T> left, TinyType<T> right)
        {
            return ReferenceEquals(left, null) || left.CompareTo(right) <= 0;
        }

        /// <summary>
        /// Overriding operator for greater than check between two <see cref="TinyType{T}"/> instances.
        /// </summary>
        /// <param name="left">First instance to be compared.</param>
        /// <param name="right">Second instance to be compared.</param>
        /// <returns>Indicates whether the left instance is greater than the right instance.</returns>
        public static bool operator >(TinyType<T> left, TinyType<T> right)
        {
            return !ReferenceEquals(left, null) && left.CompareTo(right) > 0;
        }

        /// <summary>
        /// Overriding operator for greater than or equal to check between two <see cref="TinyType{T}"/> instances.
        /// </summary>
        /// <param name="left">First instance to be compared.</param>
        /// <param name="right">Second instance to be compared.</param>
        /// <returns>Indicates whether the left instance is greater than or equal to the right instance.</returns>
        public static bool operator >=(TinyType<T> left, TinyType<T> right)
        {
            return ReferenceEquals(left, null) ? ReferenceEquals(right, null) : left.CompareTo(right) >= 0;
        }

        /// <inheritdoc />
        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (obj.GetType() != this.GetType())
            {
                return false;
            }

            return this.Equals((TinyType<T>)obj);
        }

        /// <inheritdoc />
        public bool Equals(TinyType<T>? other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return this.Equals(other.Value);
        }

        /// <inheritdoc />
        public override int GetHashCode()
        {
            return EqualityComparer<T>.Default.GetHashCode(this.Value);
        }

        /// <inheritdoc />
        public virtual int CompareTo(TinyType<T> other)
        {
            if (other == null)
            {
                throw new ArgumentNullException(nameof(other), $"Cannot compare {this.GetType()} to null.");
            }

            return this.Value.CompareTo(other.Value);
        }

        /// <inheritdoc />
        public int CompareTo(object? obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(nameof(obj), $"Cannot compare {this.GetType()} to null.");
            }

            if (this.GetType() != obj.GetType())
            {
                throw new ArgumentException($"Cannot compare {this.GetType()} to {obj.GetType()}.");
            }

            return this.CompareTo((TinyType<T>)obj);
        }

        /// <summary>
        /// Indicates whether the underlying object is equal to another object of the same type.
        /// </summary>
        /// <param name="other">Other underlying value.</param>
        /// <returns>Whether the underlying values are equal.</returns>
        protected virtual bool Equals(T other)
        {
            return EqualityComparer<T>.Default.Equals(this.Value, other);
        }
    }
}
