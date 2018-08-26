using System.ComponentModel;

namespace Dates.Recurring
{
    public enum Ordinal : int
    {
        [Description("First")]
        FIRST = 1,
        [Description("Second")]
        SECOND = 2,
        [Description("Third")]
        THIRD = 3,
        [Description("Fourth")]
        FOURTH = 4,
        [Description("Last")]
        LAST = 5,
    }
}
