using Dates.Recurring.Type;
using System;

namespace Dates.Recurring.Builders
{
    public class WeeksBuilder
    {
        private int _weeks;
        private DateTime _starting;
        private DateTime? _ending;
        private int? _endingAfter;
        private Day _days;
        private DayOfWeek _firstDayOfWeek = DayOfWeek.Sunday;

        public WeeksBuilder(int weeks, DateTime starting)
        {
            _weeks = weeks;
            _starting = starting;
            _days = Day.MONDAY;
        }

        public WeeksBuilder Ending(DateTime ending)
        {
            _ending = ending;
            return this;
        }

        public WeeksBuilder EndingAfter(int endingAfter)
        {
            _endingAfter = endingAfter;
            return this;
        }

        public WeeksBuilder OnDays(Day days)
        {
            _days = days;
            return this;
        }

        public WeeksBuilder OnDay(DayOfWeek day)
        {
            switch(day)
            {
                case DayOfWeek.Sunday:
                    _days = Day.SUNDAY;
                    break;
                case DayOfWeek.Monday:
                    _days = Day.MONDAY;
                    break;
                case DayOfWeek.Tuesday:
                    _days = Day.TUESDAY;
                    break;
                case DayOfWeek.Wednesday:
                    _days = Day.WEDNESDAY;
                    break;
                case DayOfWeek.Thursday:
                    _days = Day.THURSDAY;
                    break;
                case DayOfWeek.Friday:
                    _days = Day.FRIDAY;
                    break;
                case DayOfWeek.Saturday:
                    _days = Day.SATURDAY;
                    break;
            }
            return this;
        }

        public WeeksBuilder FirstDayOfWeek(DayOfWeek day)
        {
            _firstDayOfWeek = day;
            return this;
        }

        public Weekly Build()
        {
            return new Weekly(_weeks, _starting, _ending, _endingAfter, _days, _firstDayOfWeek);
        }
    }
}
