using Dates.Recurring.Type;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dates.Recurring.Builders
{
    public class YearsBuilder
    {
        private int _skipYears;
        private int _dayOfMonth = 1;
        private Month _month = Month.JANUARY;
        private DateTime _starting;
        private DateTime? _ending;

        public YearsBuilder(int skipYears, DateTime starting)
        {
            _skipYears = skipYears;
            _starting = starting;
        }

        public YearsBuilder Ending(DateTime ending)
        {
            _ending = ending;
            return this;
        }

        public YearsBuilder OnDay(int dayOfMonth)
        {
            _dayOfMonth = dayOfMonth;
            return this;
        }

        public YearsBuilder OnMonths(Month months)
        {
            _month = months;
            return this;
        }

        public Yearly Build()
        {
            return new Yearly(_skipYears, _dayOfMonth, _month, _starting, _ending);
        }
    }
}
