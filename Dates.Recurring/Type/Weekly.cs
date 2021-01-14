using System;
using Humanizer;

namespace Dates.Recurring.Type
{
    public class Weekly : RecurrenceType
    {
        public Day Days { get; set; }
        public DayOfWeek FirstDayOfWeek { get; set; }
        private DayOfWeek LastDayOfWeek
        {
            get
            {
                if (this.FirstDayOfWeek == DayOfWeek.Sunday)
                {
                    return DayOfWeek.Saturday;
                }
                else
                {
                    return this.FirstDayOfWeek - 1;
                }
            }
        }

        public Weekly(int weeks, DateTime starting, DateTime? ending, int? endingAfter, Day days, DayOfWeek firstDayOfWeek) : base(weeks, starting, ending, endingAfter)
        {
            Days = days;
            FirstDayOfWeek = firstDayOfWeek;
        }

        public override DateTime? Next(DateTime after)
        {
            var next = Starting;
            int iterations = 1;

            if (after.Date < Starting.Date)
            {
                after = Starting - 1.Days();
            }

            while (next.Date <= after.Date || !DayOfWeekMatched(next.DayOfWeek))
            {
                if (DayOfWeekMatched(next.DayOfWeek))
                {
                    iterations++;
                }

                next = GetNextCandidate(next);
            }

            if (Ending.HasValue && next.Date > Ending.Value.Date)
            {
                return null;
            }

            if (EndingAfter.HasValue && iterations > EndingAfter)
            {
                return null;
            }

            return next;
        }

        public override DateTime? Previous(DateTime before)
        {
            int iterations = 0;

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

            while (next.Date < before.Date)
            {
                if (DayOfWeekMatched(next.DayOfWeek))
                {
                    last = next;
                    iterations++;
                }

                next = GetNextCandidate(next);
                
                if (!DayOfWeekMatched(next.DayOfWeek) && EndingAfter.HasValue && iterations >= EndingAfter)
                {
                    break;
                }
            }

            return last;
        }

        private bool DayOfWeekMatched(DayOfWeek day)
        {
            if (day == DayOfWeek.Sunday && (Days & Day.SUNDAY) != 0)
                return true;

            if (day == DayOfWeek.Monday && (Days & Day.MONDAY) != 0)
                return true;

            if (day == DayOfWeek.Tuesday && (Days & Day.TUESDAY) != 0)
                return true;

            if (day == DayOfWeek.Wednesday && (Days & Day.WEDNESDAY) != 0)
                return true;

            if (day == DayOfWeek.Thursday && (Days & Day.THURSDAY) != 0)
                return true;

            if (day == DayOfWeek.Friday && (Days & Day.FRIDAY) != 0)
                return true;

            if (day == DayOfWeek.Saturday && (Days & Day.SATURDAY) != 0)
                return true;

            return false;
        }

        private DateTime GetNextCandidate(DateTime next)
        {
            if (next.DayOfWeek != LastDayOfWeek)
            {
                return next + 1.Days();
            }
            else
            {
                // Skip ahead by x weeks.
                next = next + X.Weeks();

                // Rewind to the first day of the week.
                int delta = FirstDayOfWeek - next.DayOfWeek;
                if (delta > 0)
                {
                    delta -= 7;
                }
                return next + delta.Days();
            }
        }
    }
}
