using System;
using Dates.Recurring.Type;

namespace Dates.Recurring.Builders
{
    public class DaysBuilder
    {
        private int _days;
        private DateTime _starting;
        private DateTime? _ending;

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

        public Daily Build()
        {
            return new Daily(_days, _starting, _ending);
        }


    }
}
