using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dates.Recurring.Type
{
    public abstract class RecurrenceType : IRecurring
    {
        protected int X { get; set; }
        protected DateTime Starting { get; set; }
        protected DateTime? Ending { get; set; }

        public RecurrenceType(int x, DateTime starting, DateTime? ending = null)
        {
            X = x;
            Starting = starting;
            Ending = ending;
        }

        public abstract DateTime? Next(DateTime after);
    }
}
