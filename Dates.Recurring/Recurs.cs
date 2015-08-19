using Dates.Recurring.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
