using System;
using Humanizer;

namespace Dates.Recurring.Type
{
    public class Yearly : RecurrenceType
    {
        public int? DayOfMonth { get; set; }
        public Ordinal? OrdinalWeek { get; set; }
        public DayOfWeek? DayOfWeek { get; set; }

        public Month Month { get; set; }

        private readonly bool isSpecificDayOfMonth;

        public Yearly(int skipYears, int? dayOfMonth, Month month, DateTime starting, DateTime? ending)
            : base(skipYears, starting, ending)
        {
            DayOfMonth = dayOfMonth;
            Month = month;
            isSpecificDayOfMonth = true;
        }

        public Yearly(int skipYears, Ordinal? ordinalWeek, DayOfWeek? dayOfWeek, Month month, DateTime starting, DateTime? ending)
            : base(skipYears, starting, ending)
        {
            OrdinalWeek = ordinalWeek;
            DayOfWeek = dayOfWeek;
            Month = month;
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

            if (after.Date < Starting.Date)
            {
                after = Starting - 1.Days();
            }

            var targetDay = OrdinalTargetDay(next.Month, next.Year);

            while (next.Date < after.Date || !MonthMatched(next) || !DayOfMonthMatched(targetDay, next))
            {
                var candidate = GetNextOrdinalCandidate(next, targetDay);

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
                if (MonthMatched(next) && DayOfMonthMatched(targetDay, next))
                {
                    last = next;
                }

                var candidate = GetNextOrdinalCandidate(next, targetDay);

                next = candidate.Date;
                targetDay = candidate.TargetDay;
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

            while (next.Date < after.Date || !MonthMatched(next) || !DayOfMonthMatched(DayOfMonth.Value, next))
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
                if (MonthMatched(next) && DayOfMonthMatched(DayOfMonth.Value, next))
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

        private bool MonthMatched(DateTime date)
        {
            if (date.Month == 1 && (Month & Month.JANUARY) != 0)
                return true;

            if (date.Month == 2 && (Month & Month.FEBRUARY) != 0)
                return true;

            if (date.Month == 3 && (Month & Month.MARCH) != 0)
                return true;

            if (date.Month == 4 && (Month & Month.APRIL) != 0)
                return true;

            if (date.Month == 5 && (Month & Month.MAY) != 0)
                return true;

            if (date.Month == 6 && (Month & Month.JUNE) != 0)
                return true;

            if (date.Month == 7 && (Month & Month.JULY) != 0)
                return true;

            if (date.Month == 8 && (Month & Month.AUGUST) != 0)
                return true;

            if (date.Month == 9 && (Month & Month.SEPTEMBER) != 0)
                return true;

            if (date.Month == 10 && (Month & Month.OCTOBER) != 0)
                return true;

            if (date.Month == 11 && (Month & Month.NOVEMBER) != 0)
                return true;

            if (date.Month == 12 && (Month & Month.DECEMBER) != 0)
                return true;

            return false;
        }

        private OrdinalDayCandidate GetNextOrdinalCandidate(DateTime current, int targetDay)
        {
            if (!MonthMatched(current))
            {
                if (current.Month == 12)
                {
                    // Rewind to the first of the month.
                    current = current + ((-1 * current.Day) + 1).Days();

                    // Rewind to the first month
                    current = current.AddMonths((-1 * current.Month) + 1);

                    // Skip ahead by the required number of years.
                    current = current.AddYears(X);

                    targetDay = OrdinalTargetDay(current.Month, current.Year);
                }
                else
                {
                    // Rewind to the first of the month.
                    current = current + ((-1 * current.Day) + 1).Days();

                    // Skip to the next month.
                    current = current.AddMonths(1);

                    targetDay = OrdinalTargetDay(current.Month, current.Year);
                }
            }
            else
            {
                int dayOfMonth = Math.Min(targetDay, DateTime.DaysInMonth(current.Year, current.Month));

                if (current.Day < dayOfMonth)
                {
                    current = current + 1.Days();
                }
                else
                {
                    // Rewind to the first of the month.
                    current = current + ((-1 * current.Day) + 1).Days();

                    // Skip to the next month.
                    current = current.AddMonths(1);

                    targetDay = OrdinalTargetDay(current.Month, current.Year);
                }
            }

            return new OrdinalDayCandidate(current, targetDay);
        }

        private DateTime GetNextSpecificDayCandidate(DateTime current)
        {
            if (!MonthMatched(current))
            {
                if (current.Month == 12)
                {
                    // Rewind to the first of the month.
                    current = current + ((-1 * current.Day) + 1).Days();

                    // Rewind to the first month
                    current = current.AddMonths((-1 * current.Month) + 1);

                    // Skip ahead by the required number of years.
                    current = current.AddYears(X);
                }
                else
                {
                    // Rewind to the first of the month.
                    current = current + ((-1 * current.Day) + 1).Days();

                    // Skip to the next month.
                    current = current.AddMonths(1);
                }
            }
            else
            {
                int dayOfMonth = Math.Min(DayOfMonth.Value, DateTime.DaysInMonth(current.Year, current.Month));

                if (current.Day < dayOfMonth)
                {
                    current = current + 1.Days();
                }
                else
                {
                    // Rewind to the first of the month.
                    current = current + ((-1 * current.Day) + 1).Days();

                    // Skip to the next month.
                    current = current.AddMonths(1);
                }
            }

            return current;
        }
    }
}
