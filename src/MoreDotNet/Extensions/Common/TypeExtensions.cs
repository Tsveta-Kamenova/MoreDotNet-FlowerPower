﻿namespace MoreDotNet.Extensions.Common
{
    using System;
    using System.Reflection;

    /// <summary>
    /// <see cref="Type"/> extensions.
    /// </summary>
    public static class TypeExtensions
    {
        /// <summary>
        /// Determine of specified type is nullable
        /// </summary>
        /// <param name="input">The <see cref="Type"/> instance on which the extension method is called.</param>
        /// <returns>True if the <paramref name="input"/> is nullable.</returns>
        public static bool IsNullable(this Type input)
        {
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }

            return !input.GetTypeInfo().IsValueType ||
                (input.GetTypeInfo().IsGenericType && input.GetGenericTypeDefinition() == typeof(Nullable<>));
        }

        /// <summary>
        /// Return underlying type if type is nullable otherwise return the type
        /// </summary>
        /// <param name="input">The <see cref="Type"/> instance on which the extension method is called.</param>
        /// <returns>The underlying type of the nullable type or if the type is not nullable - the same type.</returns>
        public static Type GetCoreType(this Type input)
        {
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }

            if (IsNullable(input))
            {
                if (!input.GetTypeInfo().IsValueType)
                {
                    return input;
                }

                return Nullable.GetUnderlyingType(input);
            }

            return input;
        }
    }
}
