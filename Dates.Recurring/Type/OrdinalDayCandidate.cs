using System;

namespace Dates.Recurring.Type
{
    internal struct OrdinalDayCandidate
    {
        public OrdinalDayCandidate(DateTime date, int targetDay)
        {
            Date = date;
            TargetDay = targetDay;
        }

        public DateTime Date { get; }
        public int TargetDay { get; }
    }
}
