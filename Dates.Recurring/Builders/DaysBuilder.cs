using System;
using Dates.Recurring.Type;

namespace Dates.Recurring.Builders
{
    public class DaysBuilder
    {
        private int _days;
        private DateTime _starting;
        private DateTime? _ending;
        private Day _includeDays = Day.SUNDAY | Day.MONDAY | Day.TUESDAY | Day.WEDNESDAY | Day.THURSDAY | Day.FRIDAY | Day.SATURDAY;

        public DaysBuilder(int days, DateTime starting)
        {
            _days = days;
            _starting = starting;
        }

        public DaysBuilder Ending(DateTime ending)
        {
            _ending = ending;
            return this;
        }

        public DaysBuilder Including(Day includeDays)
        {
            _includeDays = includeDays;
            return this;
        }

        public Daily Build()
        {
            return new Daily(_days, _includeDays, _starting, _ending);
        }


    }
}
