﻿namespace MoreDotNet.Extensions.Collections
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// <see cref="IDictionary{TKey,TValue}"/> extensions.
    /// </summary>
    public static class DictionaryExtensions
    {
        /// <summary>
        /// If a key exists in a dictionary, return its value,
        /// otherwise return the default value for that type.
        /// </summary>
        /// <typeparam name="TKey">The key type of the <see cref="IDictionary{TKey,TValue}"/></typeparam>
        /// <typeparam name="TValue">The value type of the <see cref="IDictionary{TKey,TValue}"/></typeparam>
        /// <param name="dictionary">The <see cref="IDictionary{TKey,TValue}"/> instance on which the extension method is called.</param>
        /// <param name="key">The key we are searching for.</param>
        /// <returns>
        /// The associated value with the given <paramref name="key"/> or if the key does not exists - the default value of generic value type.
        /// </returns>
        public static TValue GetOrDefault<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key)
        {
            if (dictionary == null)
            {
                throw new ArgumentNullException(nameof(dictionary));
            }

            return dictionary.GetOrDefault(key, default(TValue));
        }

        /// <summary>
        /// If a key exists in a dictionary, return its value,
        /// otherwise return the provided default value.
        /// </summary>
        /// <typeparam name="TKey">The key type of the <see cref="IDictionary{TKey,TValue}"/></typeparam>
        /// <typeparam name="TValue">The value type of the <see cref="IDictionary{TKey,TValue}"/></typeparam>
        /// <param name="dictionary">The <see cref="IDictionary{TKey,TValue}"/> instance on which the extension method is called.</param>
        /// <param name="key">The key we are searching for.</param>
        /// <param name="defaultValue">A default value if the <paramref name="key"/> does not exist in the <paramref name="dictionary"/></param>
        /// <returns>
        /// The associated value with the given <paramref name="key"/> or if the key does not exists - <paramref name="defaultValue"/>
        /// </returns>
        public static TValue GetOrDefault<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key, TValue defaultValue)
        {
            if (dictionary == null)
            {
                throw new ArgumentNullException(nameof(dictionary));
            }

            TValue outValue;
            var hasValue = dictionary.TryGetValue(key, out outValue);

            if (hasValue)
            {
                return outValue;
            }

            return defaultValue;
        }

        /// <summary>
        /// Gets the key using <paramref name="caseInsensitiveKey"/> from <paramref name="dictionary"/>.
        /// </summary>
        /// <typeparam name="T">The dictionary value.</typeparam>
        /// <param name="dictionary">The <see cref="IDictionary{TKey,TValue}"/> instance on which the extension method is called.</param>
        /// <param name="caseInsensitiveKey">The case insensitive key.</param>
        /// <returns>
        /// An existing key; or <see cref="string.Empty"/> if not found.
        /// </returns>
        public static string GetKeyIgnoringCase<T>(this IDictionary<string, T> dictionary, string caseInsensitiveKey)
        {
            if (dictionary == null)
            {
                throw new ArgumentNullException(nameof(dictionary));
            }

            if (string.IsNullOrEmpty(caseInsensitiveKey))
            {
                return string.Empty;
            }

            foreach (var key in dictionary.Keys)
            {
                if (key.Equals(caseInsensitiveKey, StringComparison.CurrentCultureIgnoreCase))
                {
                    return key;
                }
            }

            return string.Empty;
        }
    }
}
