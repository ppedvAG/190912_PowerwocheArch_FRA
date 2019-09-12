using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDDBankkonto
{
    public class OpeningHours
    {
        public bool IsOpen(DateTime dateTime)
        {
            switch (dateTime.DayOfWeek)
            {
                case DayOfWeek.Monday:
                case DayOfWeek.Tuesday:
                case DayOfWeek.Wednesday:
                case DayOfWeek.Thursday:
                case DayOfWeek.Friday:
                    // 10:30 - 19:00
                    TimeSpan min = new TimeSpan(10, 30, 00);
                    TimeSpan max = new TimeSpan(19, 00, 00);

                    return dateTime.TimeOfDay >= min && dateTime.TimeOfDay < max;
                case DayOfWeek.Saturday:
                    // 10:30 - 14:00
                    min = new TimeSpan(10, 30, 00);
                    max = new TimeSpan(14, 00, 00);

                    return dateTime.TimeOfDay >= min && dateTime.TimeOfDay < max;
                case DayOfWeek.Sunday:
                    return false;
                default:
                    throw new ArgumentException("Neues Kalendersystem wird nicht unterstützt");
            }
        }

        public bool IsNowOpen()
        {
            var result = IsOpen(DateTime.Now);
            // .... mach was
            return result;
        }
    }
}
