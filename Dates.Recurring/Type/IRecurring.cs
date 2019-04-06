using System;

namespace Dates.Recurring.Type
{
    public interface IRecurring
    {
        DateTime? Next(DateTime after);
        DateTime? Previous(DateTime before);
    }
}
