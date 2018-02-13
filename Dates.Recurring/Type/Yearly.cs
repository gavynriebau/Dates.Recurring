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

        private bool isSpecificDayOfMonth;

        public Yearly(int skipYears, int? dayOfMonth, Month month, DateTime starting, DateTime? ending) : base(skipYears, starting, ending)
        {
            DayOfMonth = dayOfMonth;
            Month = month;
            isSpecificDayOfMonth = true;
        }

        public Yearly(int skipYears, Ordinal? ordinalWeek, DayOfWeek? dayOfWeek, Month month, DateTime starting, DateTime? ending) : base(skipYears, starting, ending)
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

        private DateTime? NextOrdinal(DateTime after)
        {
            var next = Starting;

            if (after.Date < Starting.Date)
            {
                after = Starting - 1.Days();
            }

            var targetDay = OrdinalTargetDay(next.Month, next.Year);

            while (next.Date <= after.Date || !MonthMatched(next) || !DayOfMonthMatched(targetDay, next))
            {
                if (!MonthMatched(next))
                {
                    if (next.Month == 12)
                    {
                        // Rewind to the first of the month.
                        next = next + ((-1 * next.Day) + 1).Days();

                        // Rewind to the first month
                        next = next.AddMonths((-1 * next.Month) + 1);

                        // Skip ahead by the required number of years.
                        next = next.AddYears(X);

                        targetDay = OrdinalTargetDay(next.Month, next.Year);
                    }
                    else
                    {
                        // Rewind to the first of the month.
                        next = next + ((-1 * next.Day) + 1).Days();

                        // Skip to the next month.
                        next = next.AddMonths(1);

                        targetDay = OrdinalTargetDay(next.Month, next.Year);
                    }
                }
                else
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

                        // Skip to the next month.
                        next = next.AddMonths(1);

                        targetDay = OrdinalTargetDay(next.Month, next.Year);
                    }
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

            while (next.Date <= after.Date || !MonthMatched(next) || !DayOfMonthMatched(DayOfMonth.Value, next))
            {
                if (!MonthMatched(next))
                {
                    if (next.Month == 12)
                    {
                        // Rewind to the first of the month.
                        next = next + ((-1 * next.Day) + 1).Days();

                        // Rewind to the first month
                        next = next.AddMonths((-1 * next.Month) + 1);

                        // Skip ahead by the required number of years.
                        next = next.AddYears(X);
                    }
                    else
                    {
                        // Rewind to the first of the month.
                        next = next + ((-1 * next.Day) + 1).Days();

                        // Skip to the next month.
                        next = next.AddMonths(1);
                    }
                }
                else
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

                        // Skip to the next month.
                        next = next.AddMonths(1);
                    }
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

        private bool MonthMatched(DateTime date)
        {
            if (date.Month == 1 && (Month & Recurring.Month.JANUARY) != 0)
                return true;

            if (date.Month == 2 && (Month & Recurring.Month.FEBRUARY) != 0)
                return true;

            if (date.Month == 3 && (Month & Recurring.Month.MARCH) != 0)
                return true;

            if (date.Month == 4 && (Month & Recurring.Month.APRIL) != 0)
                return true;

            if (date.Month == 5 && (Month & Recurring.Month.MAY) != 0)
                return true;

            if (date.Month == 6 && (Month & Recurring.Month.JUNE) != 0)
                return true;

            if (date.Month == 7 && (Month & Recurring.Month.JULY) != 0)
                return true;

            if (date.Month == 8 && (Month & Recurring.Month.AUGUST) != 0)
                return true;

            if (date.Month == 9 && (Month & Recurring.Month.SEPTEMBER) != 0)
                return true;

            if (date.Month == 10 && (Month & Recurring.Month.OCTOBER) != 0)
                return true;

            if (date.Month == 11 && (Month & Recurring.Month.NOVEMBER) != 0)
                return true;

            if (date.Month == 12 && (Month & Recurring.Month.DECEMBER) != 0)
                return true;

            return false;
        }
    }
}
