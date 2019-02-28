using System;
using System.ComponentModel;

namespace Dates.Recurring
{
    [Flags]
    public enum Month : int
    {
        [Description("January")]
        JANUARY = 1,
        [Description("February")]
        FEBRUARY = 2,
        [Description("March")]
        MARCH = 4,
        [Description("April")]
        APRIL = 8,
        [Description("May")]
        MAY = 16,
        [Description("June")]
        JUNE = 32,
        [Description("July")]
        JULY = 64,
        [Description("August")]
        AUGUST = 128,
        [Description("September")]
        SEPTEMBER = 256,
        [Description("October")]
        OCTOBER = 512,
        [Description("November")]
        NOVEMBER = 1024,
        [Description("December")]
        DECEMBER = 2048
    }
}
