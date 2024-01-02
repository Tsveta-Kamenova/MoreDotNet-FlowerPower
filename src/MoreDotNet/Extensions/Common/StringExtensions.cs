﻿namespace MoreDotNet.Extensions.Common
{
    using System;
    using System.Globalization;
    using System.Text.RegularExpressions;
    using System.Threading;

    using MoreDotNet.Wrappers;

    /// <summary>
    /// <see cref="string"/> extensions.
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Provides a title case of the supplied string.
        /// </summary>
        /// <param name="input">The string instance on which the extension method is called.</param>
        /// <returns>The string in title case.</returns>
        public static string ToTitleCase(this string input)
        {
            var tokens = input.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            for (var i = 0; i < tokens.Length; i++)
            {
                var token = tokens[i];
                tokens[i] = token.Substring(0, 1).ToUpper() + token.Substring(1).ToLower();
            }

            return string.Join(" ", tokens);
        }

        /// <summary>
        /// Transforms a pascal case or camel case string to separate words.
        /// </summary>
        /// <param name="input">The string instance on which the extension method is called.</param>
        /// <returns>The separated words.</returns>
        public static string CaseToWords(this string input)
        {
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }

            // if the input is all upper, just return it
            if (!Regex.IsMatch(input, "[a-z]"))
            {
                return input;
            }

            return string.Join(" ", Regex.Split(input, @"(?<!^)(?=[A-Z])"));
        }

        /// <summary>
        /// Makes the first character of a string upper case.
        /// </summary>
        /// <param name="input">The string instance on which the extension method is called.</param>
        /// <returns>The capitalized word.</returns>
        public static string Capitalize(this string input)
        {
            if (input.IsNullOrWhiteSpace())
            {
                return input;
            }

            return input[0]
                .ToString()
                .ToUpper() + input.Substring(1);
        }

        /// <summary>
        /// Indicates whether the current string matches the supplied wild-card pattern.  Behaves the same
        /// as VB'input "Like" Operator.
        /// </summary>
        /// <param name="input">The string instance on which the extension method is called.</param>
        /// <param name="wildcardPattern">The wild-card pattern to match.  Syntax matches VB'input Like operator.</param>
        /// <returns>true if the string matches the supplied pattern, false otherwise.</returns>
        /// <exception cref="ArgumentException">Thrown when wild-card pattern is invalid.</exception>
        /// <remarks>See http://msdn.microsoft.com/en-us/library/swf8kaxw(v=VS.100).aspx</remarks>
        public static bool IsLike(this string input, string wildcardPattern)
        {
            if (input == null || string.IsNullOrEmpty(wildcardPattern))
            {
                return false;
            }

            // turn into regex pattern, and match the whole string with ^$
            var regexPattern = "^" + Regex.Escape(wildcardPattern) + "$";

            // add support for ?, #, *, [], and [!]
            regexPattern = regexPattern.Replace(@"\[!", "[^")
                                       .Replace(@"\[", "[")
                                       .Replace(@"\]", "]")
                                       .Replace(@"\?", ".")
                                       .Replace(@"\*", ".*")
                                       .Replace(@"\#", @"\d");

            bool result;
            try
            {
                result = Regex.IsMatch(input, regexPattern);
            }
            catch (ArgumentException ex)
            {
                throw new ArgumentException($"Invalid pattern: {wildcardPattern}", ex);
            }

            return result;
        }

        /// <summary>
        /// Trims excessive text over some maximum length and replaces it with a specified string.
        /// </summary>
        /// <param name="input">The string instance on which the extension method is called.</param>
        /// <param name="maximumLength">The maximum length of text to be preserved.</param>
        /// <param name="postFixText">The replacement string for the excessive text.</param>
        /// <exception cref="ArgumentNullException">Thrown when input or postfix text is null.</exception>
        /// <returns>The trimmed string.</returns>
        public static string ToMaximumLengthString(this string input, int maximumLength, string postFixText = "...")
        {
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }

            if (postFixText == null)
            {
                throw new ArgumentNullException(nameof(postFixText));
            }

            if (input.Length > maximumLength)
            {
                return string.Format(
                    CultureInfo.InvariantCulture,
                    "{0}{1}",
                    input.Substring(0, maximumLength - postFixText.Length),
                    postFixText);
            }

            return input;
        }

        /// <summary>
        /// Gets the index of the n-th occurrence of a specified string.
        /// </summary>
        /// <param name="input">The string instance on which the extension method is called.</param>
        /// <param name="match">The string we are searching for.</param>
        /// <param name="occurrence">Occurrence number.</param>
        /// <exception cref="ArgumentNullException">Thrown when input or match text is null.</exception>
        /// <exception cref="ArgumentException">Thrown if the occurrence is lower than 1.</exception>
        /// <returns>The index of the n-th occurrence of the <paramref name="match"/> string.</returns>
        public static int NthIndexOf(this string input, string match, int occurrence)
        {
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }

            if (match == null)
            {
                throw new ArgumentNullException(nameof(match));
            }

            const int NotFoundValue = -1;

            if (occurrence < 1)
            {
                throw new ArgumentException("occurrence equal to 1 or larger.", nameof(occurrence));
            }

            var i = 1;
            var index = 0;

            while (i <= occurrence &&
                (index = input.IndexOf(match, index + 1, StringComparison.Ordinal)) != NotFoundValue)
            {
                if (i == occurrence)
                {
                    // Match found!
                    return index;
                }

                i++;
            }

            // Match not found
            return NotFoundValue;
        }

        /// <summary>
        /// Removes the last character of the string.
        /// </summary>
        /// <param name="input">The string instance on which the extension method is called.</param>
        /// <returns>The string without its last character.</returns>
        public static string RemoveLastCharacter(this string input)
        {
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }

            return input.Substring(0, input.Length - 1);
        }

        /// <summary>
        /// Removes the last n characters of a string.
        /// </summary>
        /// <param name="input">The string instance on which the extension method is called.</param>
        /// <param name="number">The number of characters to be removed.</param>
        /// <returns>The string without its last <paramref name="number"/> characters</returns>
        public static string RemoveLast(this string input, int number)
        {
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }

            return input.Substring(0, input.Length - number);
        }

        /// <summary>
        /// Removes the first character of the string.
        /// </summary>
        /// <param name="input">The string instance on which the extension method is called.</param>
        /// <returns>The string without its first character.</returns>
        public static string RemoveFirstCharacter(this string input)
        {
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }

            return input.Substring(1);
        }

        /// <summary>
        /// Removes the first n characters of a string.
        /// </summary>
        /// <param name="input">The string instance on which the extension method is called.</param>
        /// <param name="number">The number of characters to be removed.</param>
        /// <returns>The string without its first <paramref name="number"/> characters</returns>
        public static string RemoveFirst(this string input, int number)
        {
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }

            return input.Substring(number);
        }
    }
}
