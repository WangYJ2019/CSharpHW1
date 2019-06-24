using System;
using System.Collections.Generic;
using System.Text;

namespace AccountsClass.Extension
{
    public static class DateTimeExtension
    {
        public static bool IsSameMonthOfSameYear(this DateTime source, DateTime target)
        {
            return (source.Month == target.Month && source.Year == target.Year);
        }
    }
}
