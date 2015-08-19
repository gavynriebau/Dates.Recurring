using Dates.Recurring.Type;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dates.Recurring.Builders
{
    public class MonthsBuilder
    {
        private int _skipMonths;
        private int _dayOfMonth = 1;
        private DateTime _starting;
        private DateTime? _ending;

        public MonthsBuilder(int skipMonths, DateTime starting)
        {
            _skipMonths = skipMonths;
            _starting = starting;
        }

        public MonthsBuilder Ending(DateTime ending)
        {
            _ending = ending;
            return this;
        }

        public MonthsBuilder OnDay(int dayOfMonth)
        {
            _dayOfMonth = dayOfMonth;
            return this;
        }

        public Monthly Build()
        {
            return new Monthly(_skipMonths, _dayOfMonth, _starting, _ending);
        }
    }
}
