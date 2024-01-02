﻿namespace MoreDotNet.Extensions.Common
{
    using System;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Reflection;

    /// <summary>
    /// Enum types extensions.
    /// </summary>
    public static class EnumExtensions
    {
        // TODO: Review For duplication
        public static string GetDisplayName<T>(this T enumerationValue)
            where T : struct
        {
            return GetDisplayName(enumerationValue, typeof(DisplayAttribute));
        }

        /// <summary>
        /// Extends the enumeration so that if it has Description attribute on top of the value, it can be taken as a friendly text instead of the basic ToString method
        /// </summary>
        /// <typeparam name="T">The type of the enum.</typeparam>
        /// <param name="enumerationValue">The value of the enum.</param>
        /// <returns>The description attribute value as a <see cref="string"/>.</returns>
        public static string GetDescription<T>(this T enumerationValue)
            where T : struct
        {
            return GetEnumDescription(enumerationValue, typeof(DescriptionAttribute));
        }

        private static string GetEnumDescription<T>(this T enumerationValue, Type descriptionType)
        {
            var type = enumerationValue.GetType();
            if (!type.GetTypeInfo().IsEnum)
            {
                throw new ArgumentException("EnumerationValue must be of Enum type", nameof(enumerationValue));
            }

            // Tries to find a DescriptionAttribute for a potential friendly name for the enum
            var memberInfo = type.GetTypeInfo().GetMember(enumerationValue.ToString());
            if (memberInfo.Length > 0)
            {
                var customAttributes = memberInfo[0]
                    .GetCustomAttributes(descriptionType, false)
                    .ToList();

                if (customAttributes.Count > 0)
                {
                    // Pull out the description value
                    return ((DescriptionAttribute)customAttributes[0]).Description;
                }
            }

            // If we have no description attribute, just return the ToString of the enum
            return enumerationValue.ToString();
        }

        private static string GetDisplayName<T>(this T value, Type descriptionType)
        {
            var type = value.GetType();

            var memberInfo = type.GetTypeInfo().GetMember(value.ToString());
            if (memberInfo.Length > 0)
            {
                var customAttributes = memberInfo[0]
                    .GetCustomAttributes(descriptionType, false)
                    .ToList();

                if (customAttributes.Count > 0)
                {
                    // Pull out the name value
                    return ((DisplayAttribute)customAttributes[0]).Name;
                }
            }

            return value.ToString();
        }
    }
}
