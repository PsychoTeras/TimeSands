using System;
using System.Collections.Generic;
using System.Linq;

namespace TimeSands.Helpers
{
    internal static class CommonHelpers
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
    }
}
