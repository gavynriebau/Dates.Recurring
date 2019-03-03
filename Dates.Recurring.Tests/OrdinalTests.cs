using System;
using Xunit;

namespace Dates.Recurring.Tests
{
    public sealed class OrdinalTests
    {
        [Fact]
        public void Ordinal_Format_Should_Not_Behave_As_Flags_Enum_On_Conversion_To_String()
        {
            Assert.Equal("THIRD", (Ordinal.FIRST | Ordinal.SECOND).ToString());
        }

        [Fact]
        public void Ordinal_Format_Should_Not_Behave_As_Flags_Enum_On_Conversion_From_String()
        {
            Ordinal result;
            Assert.True(Enum.TryParse("FIRST,SECOND", out result));
            Assert.Equal(Ordinal.THIRD, result);
        }
    }
}
