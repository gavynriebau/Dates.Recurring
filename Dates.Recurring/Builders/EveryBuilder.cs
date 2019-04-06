using System;

namespace Dates.Recurring.Builders
{
    public class EveryBuilder
    {
        private DateTime _starting;
        private int _x;

        public EveryBuilder(DateTime starting, int x)
        {
            _starting = starting;
            _x = x;
        }

        public DaysBuilder Days()
        {
            return new DaysBuilder(_x, _starting);
        }

        public WeeksBuilder Weeks()
        {
            return new WeeksBuilder(_x, _starting);
        }

        public MonthsBuilder Months()
        {
            return new MonthsBuilder(_x, _starting);
        }

        public YearsBuilder Years()
        {
            return new YearsBuilder(_x, _starting);
        }
    }
}
