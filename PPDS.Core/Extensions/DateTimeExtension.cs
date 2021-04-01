using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPDS.Core.Extensions
{
    public static class DateTimeExtension
    {
        public static bool IsBetween(this DateTime dateToCheck, DateTime dateFrom, DateTime dateTo)
        {
            if (dateToCheck >= dateFrom && dateToCheck <= dateTo) return true;
            return false;
        }
    }
}
