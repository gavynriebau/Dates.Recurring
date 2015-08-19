using Dates.Recurring.Type;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dates.Recurring.Builders
{
    public class WeeksBuilder
    {
        private int _weeks;
        private DateTime _starting;
        private DateTime? _ending;
        private Day _days;

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

        public WeeksBuilder On(Day days)
        {
            _days = days;
            return this;
        }

        public Weekly Build()
        {
            return new Weekly(_weeks, _starting, _ending, _days);
        }
    }
}
