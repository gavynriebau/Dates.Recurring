using System;

namespace Dates.Recurring.Type
{
    public abstract class RecurrenceType : IRecurring
    {
        protected int X { get; set; }
        protected DateTime Starting { get; set; }
        protected DateTime? Ending { get; set; }
        protected int? EndingAfter { get; set; }

        public RecurrenceType(int x, DateTime starting, DateTime? ending = null, int? endingAfter = null)
        {
            X = x;
            Starting = starting;
            Ending = ending;
            EndingAfter = endingAfter;
        }

        public abstract DateTime? Next(DateTime after);
        public abstract DateTime? Previous(DateTime before);
    }
}
