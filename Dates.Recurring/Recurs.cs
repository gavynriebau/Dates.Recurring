using Dates.Recurring.Builders;
using System;

namespace Dates.Recurring
{
    public static class Recurs
    {
        public static StartingBuilder Starting(DateTime start)
        {
            return new StartingBuilder(start);
        }
    }
}
