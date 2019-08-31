using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reti.NewCondeco.Entities.Utils
{
    public static class Utils
    {
        public static bool IsCurrentBooking(DateTime startDate, DateTime endDate, DateTime bDateStart, DateTime bDateEnd)
        {
            return (startDate <= bDateEnd && startDate >= bDateStart || bDateStart <= endDate && bDateStart >= startDate);
        }
    }
}
