using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inviter.Domain.Extensions
{
    public static class DateTimeExtensions
    {
        public static DateTime? SetTime(this DateTime? date, TimeSpan? time)
        {
            if (date == null) return null;
            if (time == null) return date;
            return date.Value.Date
                .AddHours(time.Value.Hours)
                .AddMinutes(time.Value.Minutes);
        }
    }
}
