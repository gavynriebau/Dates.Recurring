using System;

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
        public abstract DateTime? Previous(DateTime before);
    }
}
