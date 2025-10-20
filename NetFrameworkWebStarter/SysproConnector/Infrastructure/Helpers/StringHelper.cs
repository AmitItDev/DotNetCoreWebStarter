using System;
using System.Collections.Generic;

namespace SysproConnector.Infrastructure.Helpers
{
    public static class StringHelper
    {
        public static string AddAsPrefix(string sourceData, char prefixCharacter, int requiredLength) => GetFillingString(sourceData, prefixCharacter, requiredLength) + sourceData;

        public static string AddAsSuffix(string sourceData, char suffixCharacter, int requiredLength) => sourceData + GetFillingString(sourceData, suffixCharacter, requiredLength);

        private static string GetFillingString(string sourceData, char fillCharacter, int requiredLength)
        {
            var numberOfOccurrances = requiredLength - sourceData.Length;
            var fillingString       = string.Empty;

            for (var i = numberOfOccurrances; i > 0; i--)
            { fillingString += fillCharacter; }

            return fillingString;
        }
        public static List<string> Split(this string value, int desiredLength, bool strict = false)
        {

            EnsureValid(value, desiredLength, strict);

            if (value.Length == 0) { return new List<string>(); }

            int numberOfItems = value.Length / desiredLength;

            int remaining = (value.Length > numberOfItems * desiredLength) ? 1 : 0;

            List<string> splitted = new List<string>(numberOfItems + remaining);

            for (int i = 0; i < numberOfItems; i++)
            {
                splitted.Add(value.Substring(i * desiredLength, desiredLength));
            }

            if (remaining != 0)
            {
                splitted.Add(value.Substring(numberOfItems * desiredLength));
            }

            return splitted;
        }

        private static void EnsureValid(string value, int desiredLength, bool strict)
        {
            if (value == null) { throw new ArgumentNullException(nameof(value)); }

            if (value.Length == 0 && desiredLength != 0)
            {
                throw new ArgumentException($"The passed {nameof(value)} may not be empty if the {nameof(desiredLength)} <> 0");
            }

            if (value.Length != 0 && desiredLength < 1) { throw new ArgumentException($"The value of {nameof(desiredLength)} needs to be > 0"); }

            if (strict && (value.Length % desiredLength != 0))
            {
                throw new ArgumentException($"The passed {nameof(value)}'s length can't be split by the {nameof(desiredLength)}");
            }
        }
    }
}
