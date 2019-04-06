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
                next = MoveXDaysForward(next);
            }

            if (Ending.HasValue && next.Date > Ending.Value.Date)
            {
                return null;
            }

            return next;
        }

        public override DateTime? Previous(DateTime before)
        {
            if (before.Date <= Starting.Date)
            {
                return null;
            }

            if (Ending.HasValue && before.Date > Ending.Value)
            {
                before = Ending.Value.Date + 1.Days();
            }

            var next = Starting;
            DateTime? last = null;

            while (next.Ticks < before.Ticks)
            {
                last = next;
                next = MoveXDaysForward(next);
            }

            return last.Value;
        }

        private DateTime MoveXDaysForward(DateTime next)
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
            return next;
        }
    }
}
