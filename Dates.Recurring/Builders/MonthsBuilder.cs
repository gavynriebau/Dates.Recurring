using System;
using Dates.Recurring.Type;

namespace Dates.Recurring.Builders
{
    public class MonthsBuilder
    {
        private int _skipMonths;
        private int? _dayOfMonth;
        private Ordinal? _ordinalWeek;
        private DayOfWeek? _dayOfWeek;
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

        public MonthsBuilder OnOrdinalWeek(Ordinal ordinalWeek)
        {
            _ordinalWeek = ordinalWeek;
            return this;
        }

        public MonthsBuilder OnDay(DayOfWeek dayOfWeek)
        {
            _dayOfWeek = dayOfWeek;
            return this;
        }

        public Monthly Build()
        {
            if (_dayOfMonth != null)
            {
                return new Monthly(_skipMonths, _dayOfMonth, _starting, _ending);
            }
            return new Monthly(_skipMonths, _ordinalWeek, _dayOfWeek, _starting, _ending);
        }
    }
}
