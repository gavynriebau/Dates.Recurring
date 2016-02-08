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

        public YearsBuilder OnMonth(DateTime dateTime)
        {
            switch(dateTime.Month)
            {
                case 1:
                    _month = Month.JANUARY;
                    break;
                case 2:
                    _month = Month.FEBRUARY;
                    break;
                case 3:
                    _month = Month.MARCH;
                    break;
                case 4:
                    _month = Month.APRIL;
                    break;
                case 5:
                    _month = Month.MAY;
                    break;
                case 6:
                    _month = Month.JUNE;
                    break;
                case 7:
                    _month = Month.JULY;
                    break;
                case 8:
                    _month = Month.AUGUST;
                    break;
                case 9:
                    _month = Month.SEPTEMBER;
                    break;
                case 10:
                    _month = Month.OCTOBER;
                    break;
                case 11:
                    _month = Month.NOVEMBER;
                    break;
                case 12:
                    _month = Month.DECEMBER;
                    break;
            }
            return this;
        }

        public Yearly Build()
        {
            return new Yearly(_skipYears, _dayOfMonth, _month, _starting, _ending);
        }
    }
}
