using System;
using System.Collections.Generic;
using System.Linq;

namespace TimeSands.Common
{
    internal static class Helpers
    {
        public static IEnumerable<Tuple<int, string>> EnumToKeyValue<T>()
        {
            Type t = typeof(T);
            if (!t.IsEnum)
            {
                string msg = $"{t.Name} is not Enum";
                throw new Exception(msg);
            }

            Array enumValues = Enum.GetValues(t);
            return enumValues.Cast<object>().Select(c => new Tuple<int, string>((int)c, c.ToString()));
        }

        public static string TimeSpanToTimeString(TimeSpan timeSpan)
        {
            string sTime = string.Empty;

            if (timeSpan.Days > 0)
            {
                sTime += $"{timeSpan.Days}d ";
            }

            if (timeSpan.Hours > 0)
            {
                sTime += $"{timeSpan.Hours}h ";
            }

            if (timeSpan.Minutes > 0)
            {
                sTime += $"{timeSpan.Minutes}m ";
            }

            if (timeSpan.Seconds > 0)
            {
                sTime += $"{timeSpan.Seconds}s";
            }

            if (string.IsNullOrEmpty(sTime))
            {
                sTime = "0h";
            }

            return sTime.TrimEnd();
        }

    }
}
