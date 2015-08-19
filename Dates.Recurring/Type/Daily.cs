using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dates.Recurring.Extensions;
using Humanizer;

namespace Dates.Recurring.Type
{
    public class Daily : RecurrenceType
    {
        public Daily(int days, DateTime starting, DateTime? ending) : base(days, starting, ending)
        {
        }

        public override DateTime? Next(DateTime after)
        {
            var next = Starting;

            if (after.WithoutTimeComponents() < Starting.WithoutTimeComponents())
            {
                after = Starting - 1.Days();
            }

            while (next.WithoutTimeComponents() <= after.WithoutTimeComponents())
            {
                next = next.AddDays(X);
            }

            if (Ending.HasValue && next.WithoutTimeComponents() > Ending.Value.WithoutTimeComponents())
            {
                return null;
            }

            return next;
        }
    }
}
