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

            return isSpecificDayOfMonth ? PreviousSpecificDay(before) : PreviousOrdinal(before);
        }

        private DateTime? NextOrdinal(DateTime after)
        {
            var next = Starting;

            if (after.Date <= Starting.Date)
            {
                after = Starting - 1.Days();
            }

            var targetDay = OrdinalTargetDay(next.Month, next.Year);

            while (next.Date < after.Date || !DayOfMonthMatched(targetDay, next))
            {
                var candidate = GetNextOrdinalDayCandidate(next, targetDay);

                next = candidate.Date;
                targetDay = candidate.TargetDay;
            }

            if (Ending.HasValue && next.Date >= Ending.Value.Date)
            {
                return null;
            }

            return next;
        }

        private DateTime? PreviousOrdinal(DateTime before)
        {
            var next = Starting;
            DateTime? last = null;

            var targetDay = OrdinalTargetDay(next.Month, next.Year);

            while (next.Date < before.Date)
            {
                if (DayOfMonthMatched(targetDay, next))
                {
                    last = next;
                }

                var nextCandidate = GetNextOrdinalDayCandidate(next, targetDay);

                next = nextCandidate.Date;
                targetDay = nextCandidate.TargetDay;
            }

            return last;
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
                next = GetNextSpecificDayCandidate(next);
            }

            if (Ending.HasValue && next.Date >= Ending.Value.Date)
            {
                return null;
            }

            return next;
        }

        private DateTime? PreviousSpecificDay(DateTime before)
        {
            var next = Starting;
            DateTime? last = null;

            while (next.Date < before.Date)
            {
                if (DayOfMonthMatched(DayOfMonth.Value, next))
                {
                    last = next;
                }

                next = GetNextSpecificDayCandidate(next);
            }

            return last;
        }

        private bool DayOfMonthMatched(int currentDayOfMonth, DateTime targetDate)
        {
            int dayOfMonth = Math.Min(currentDayOfMonth, DateTime.DaysInMonth(targetDate.Year, targetDate.Month));
            return (targetDate.Day == dayOfMonth);
        }

        private DateTime GetNextSpecificDayCandidate(DateTime current)
        {
            int dayOfMonth = Math.Min(DayOfMonth.Value, DateTime.DaysInMonth(current.Year, current.Month));

            if (current.Day < dayOfMonth)
            {
                return current + 1.Days();
            }
            else
            {
                // Rewind to the first of the month.
                current = current + ((-1 * current.Day) + 1).Days();

                // Skip ahead by the required number of months.
                return current.AddMonths(X);
            }
        }
        
        private OrdinalDayCandidate GetNextOrdinalDayCandidate(DateTime current, int targetDay)
        {
            int dayOfMonth = Math.Min(targetDay, DateTime.DaysInMonth(current.Year, current.Month));

            if (current.Day < dayOfMonth)
            {
                current = current + 1.Days();

                return new OrdinalDayCandidate(current, targetDay);
            }
            else
            {
                // Rewind to the first of the month.
                current = current + ((-1 * current.Day) + 1).Days();

                // Skip ahead by the required number of months.
                current = current.AddMonths(X);

                targetDay = OrdinalTargetDay(current.Month, current.Year);

                return new OrdinalDayCandidate(current, targetDay);
            }
        }

        private struct OrdinalDayCandidate
        {
            public OrdinalDayCandidate(DateTime date, int targetDay)
            {
                Date = date;
                TargetDay = targetDay;
            }

            public DateTime Date { get; }
            public int TargetDay { get; }
        }
    }
}
