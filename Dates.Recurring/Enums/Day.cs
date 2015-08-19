using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dates.Recurring
{
    [Flags]
    public enum Day : int
    {
        [Description("Sunday")]
        SUNDAY = 1,
        [Description("Monday")]
        MONDAY = 2,
        [Description("Tuesday")]
        TUESDAY = 4,
        [Description("Wednesday")]
        WEDNESDAY = 8,
        [Description("Thursday")]
        THURSDAY = 16,
        [Description("Friday")]
        FRIDAY = 32,
        [Description("Saturday")]
        SATURDAY = 64
    }
}
