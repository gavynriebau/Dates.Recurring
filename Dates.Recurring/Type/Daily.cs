using System;
using Humanizer;

namespace Dates.Recurring.Type
{
    public class Daily : RecurrenceType
    {
        public Daily(int days, DateTime starting, DateTime? ending) : base(days, starting, ending)
        {
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
                next = next.AddDays(X);
            }

            if (Ending.HasValue && next.Date > Ending.Value.Date)
            {
                return null;
            }

            return next;
        }
    }
}
