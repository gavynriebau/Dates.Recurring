using System;
using Humanizer;

namespace Dates.Recurring.Type
{
    public class Monthly : RecurrenceType
    {
        public int? DayOfMonth { get; set; }
        public Ordinal? OrdinalWeek { get; set; }
        public DayOfWeek? DayOfWeek { get; set; }

        private bool isSpecificDayOfMonth;

        public Monthly(int skipMonths, int? dayOfMonth, DateTime starting, DateTime? ending) : base(skipMonths, starting, ending)
        {
            DayOfMonth = dayOfMonth;
            isSpecificDayOfMonth = true;
        }

        public Monthly(int skipMonths, Ordinal? ordinalWeek, DayOfWeek? dayOfWeek, DateTime starting, DateTime? ending) : base(skipMonths, starting, ending)
        {
            OrdinalWeek = ordinalWeek;
            DayOfWeek = dayOfWeek;
            isSpecificDayOfMonth = false;
        }

        public override DateTime? Next(DateTime after)
        {
            return isSpecificDayOfMonth ? NextSpecificDay(after) : NextOrdinal(after);
        }


        private DateTime? NextOrdinal(DateTime after)
        {
            var next = Starting;

            if (after.Date < Starting.Date)
            {
                after = Starting - 1.Days();
            }

            var targetDay = OrdinalTargetDay(next.Month, next.Year);

            while (next.Date <= after.Date || !DayOfMonthMatched(targetDay, next))
            {
                int dayOfMonth = Math.Min(targetDay, DateTime.DaysInMonth(next.Year, next.Month));

                if (next.Day < dayOfMonth)
                {
                    next = next + 1.Days();
                }
                else
                {
                    // Rewind to the first of the month.
                    next = next + ((-1 * next.Day) + 1).Days();

                    // Skip ahead by the required number of months.
                    next = next.AddMonths(X);

                    targetDay = OrdinalTargetDay(next.Month, next.Year);

                }
            }

            if (Ending.HasValue && next.Date >= Ending.Value.Date)
            {
                return null;
            }

            return next;
        }

        private int OrdinalTargetDay(int month, int year)
        {
            var firstDayOfMonth = new DateTime(year, month, 1);
            var distance = DayOfWeek.Value - firstDayOfMonth.DayOfWeek;
            var firstInstanceOfDay = firstDayOfMonth.AddDays(distance) + (distance >= 0 ? 0.Days() : 7.Days());

            if (OrdinalWeek.Value == Ordinal.LAST)
            {
                return firstInstanceOfDay.AddDays(((DateTime.DaysInMonth(year, month) - firstInstanceOfDay.Day) >= 28 ? 28.Days() : 21.Days()).Days).Day;
            }

            return firstInstanceOfDay.AddDays(((int)OrdinalWeek.Value - 1) * 7).Day;
        }

        private DateTime? NextSpecificDay(DateTime after)
        {
            var next = Starting;

            if (after.Date < Starting.Date)
            {
                after = Starting - 1.Days();
            }

            while (next.Date <= after.Date || !DayOfMonthMatched(DayOfMonth.Value, next))
            {
                int dayOfMonth = Math.Min(DayOfMonth.Value, DateTime.DaysInMonth(next.Year, next.Month));

                if (next.Day < dayOfMonth)
                {
                    next = next + 1.Days();
                }
                else
                {
                    // Rewind to the first of the month.
                    next = next + ((-1 * next.Day) + 1).Days();

                    // Skip ahead by the required number of months.
                    next = next.AddMonths(X);
                }
            }

            if (Ending.HasValue && next.Date >= Ending.Value.Date)
            {
                return null;
            }

            return next;
        }

        private bool DayOfMonthMatched(int currentDayOfMonth, DateTime targetDate)
        {
            int dayOfMonth = Math.Min(currentDayOfMonth, DateTime.DaysInMonth(targetDate.Year, targetDate.Month));
            return (targetDate.Day == dayOfMonth);
        }

    }
}
