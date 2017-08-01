namespace Trans2QuikAdapter.Orders.Helpers
{
    using System;
    using System.Globalization;

    internal static class StringExtension
    {
        public static DateTime GetDate(this string stringValue, string format, DateTime defaultValue)
        {
            if (string.IsNullOrEmpty(stringValue))
            {
                return defaultValue;
            }

            DateTime res;
            return DateTime.TryParseExact(stringValue, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out res) ? res : defaultValue;
        }
        public static DateTime GetDate(this string stringValue, string format)
        {
            return GetDate(stringValue, format, DateTime.MinValue);
        }
        public static TimeSpan GetTimeSpan(string stringValue, TimeSpan defaultValue = new TimeSpan())
        {
            if (string.IsNullOrEmpty(stringValue))
            {
                return defaultValue;
            }

            TimeSpan res;
            return TimeSpan.TryParse(stringValue, out res) ? res : defaultValue;
        }

        public static decimal GetDecimal(this string stringValue, decimal defaultValue = decimal.Zero)
        {
            if (string.IsNullOrEmpty(stringValue))
            {
                return defaultValue;
            }

            decimal res;

            if (decimal.TryParse(stringValue, NumberStyles.Any, NumberFormatInfo.CurrentInfo, out res))
            {
                return res;
            }

            if (decimal.TryParse(stringValue, NumberStyles.Any, NumberFormatInfo.InvariantInfo, out res))
            {
                return res;
            }

            return defaultValue;
        }
        public static decimal GetRoundedDecimal(this string stringValue, decimal defaultValue = decimal.Zero)
        {
            var res = GetDecimal(stringValue, defaultValue);
            return Math.Round(res, 2, MidpointRounding.AwayFromZero);
        }

        public static Guid GetGuid(this string stringValue, Guid defaultValue)
        {
            if (string.IsNullOrEmpty(stringValue))
            {
                return defaultValue;
            }

            Guid res;
            return Guid.TryParse(stringValue, out res) ? res : defaultValue;
        }
        public static bool GetBool(this string stringValue, bool defaultValue = false)
        {
            if (string.IsNullOrEmpty(stringValue))
            {
                return defaultValue;
            }

            bool res;
            return bool.TryParse(stringValue, out res) ? res : defaultValue;
        }
        public static bool GetBoolFromInt(this string stringValue)
        {
            return GetInt(stringValue) > 0;
        }
        public static int GetInt(this string stringValue, int defaultValue = 0)
        {
            if (string.IsNullOrEmpty(stringValue))
            {
                return defaultValue;
            }

            int res;
            return int.TryParse(stringValue, out res) ? res : defaultValue;
        }
        public static ulong GetUlong(this string stringValue, ulong defaultValue = 0UL)
        {
            if (string.IsNullOrEmpty(stringValue))
            {
                return defaultValue;
            }

            ulong res;
            return ulong.TryParse(stringValue, out res) ? res : defaultValue;
        }
        public static T GetEnum<T>(this string stringValue) where T : struct
        {
            T res;
            Enum.TryParse(stringValue, out res);
            return res;
        }

        public static string Cut(this string source, int maxLength)
        {
            if (string.IsNullOrEmpty(source))
            {
                return source;
            }

            if (maxLength <= 0)
            {
                return source;
            }

            var len = source.Length > maxLength ? maxLength : source.Length;
            return source.Substring(0, len);
        }

        public static bool IsEqual(this string source, string toCompare)
        {
            if (string.IsNullOrEmpty(toCompare))
            {
                return false;
            }

            if (string.IsNullOrEmpty(source))
            {
                return false;
            }

            return string.Compare(source, toCompare.Trim(), StringComparison.InvariantCultureIgnoreCase) == 0;
        }
    }
}
