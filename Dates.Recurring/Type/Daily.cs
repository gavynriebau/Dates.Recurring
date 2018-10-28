using System;
using Humanizer;

namespace Dates.Recurring.Type
{
    public class Daily : RecurrenceType
    {
        public Day IncludeDays { get; set; } 

        public Daily(int days, Day includeDays, DateTime starting, DateTime? ending) : base(days, starting, ending)
        {
            IncludeDays = includeDays;
        }

        public override DateTime? Next(DateTime after)
        {
            var next = Starting;

            if (after.Date < Starting.Date)
            {
                after = Starting - 1.Days();
            }

            while ((next.Ticks - after.Ticks) <= TimeSpan.TicksPerSecond)
            {
                var daysSkipped = 0;
                do
                {
                    next = next.AddDays(1);
                    if ((Convert.ToInt32(Math.Pow(2, (int)next.DayOfWeek)) & (int)IncludeDays) > 0)
                    {
                        daysSkipped++;
                    }
                } while (daysSkipped < X);
            }

            if (Ending.HasValue && next.Date > Ending.Value.Date)
            {
                return null;
            }

            return next;
        }
    }
}
