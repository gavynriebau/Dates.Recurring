using Dates.Recurring.Type;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Dates.Recurring.Tests
{
    
    public class DailyRecurrenceTests
    {
        [Fact]
        public void Daily_EveryDay()
        {
            // Arrange.
            IRecurring daily = Recurs
                .Starting(new DateTime(2015, 1, 1))
                .Every(1)
                .Days()
                .Ending(new DateTime(2015, 1, 15))
                .Build();

            // Act.

            // Assert.
            Assert.Equal(new DateTime(2015, 1, 1), daily.Next(new DateTime(2014, 7, 3)));
            Assert.Equal(new DateTime(2015, 1, 2), daily.Next(new DateTime(2015, 1, 1)));
            Assert.Equal(new DateTime(2015, 1, 3), daily.Next(new DateTime(2015, 1, 2)));
            Assert.Null(daily.Next(new DateTime(2015, 1, 15)));
        }

        [Fact]
        public void Daily_EveryThirdDay()
        {
            // Arrange.
            IRecurring daily = Recurs
                .Starting(new DateTime(2015, 1, 1))
                .Every(3)
                .Days()
                .Build();

            // Act.

            // Assert.
            Assert.Equal(new DateTime(2015, 1, 1), daily.Next(new DateTime(2014, 7, 3)));
            Assert.Equal(new DateTime(2015, 1, 4), daily.Next(new DateTime(2015, 1, 1)));
            Assert.Equal(new DateTime(2015, 1, 7), daily.Next(new DateTime(2015, 1, 5)));
        }

        [Fact]
        public void Daily_EveryDay_ExcludeWeekends()
        {
            // Arrange.
            IRecurring daily = Recurs
                .Starting(new DateTime(2015, 1, 1))
                .Every(1)
                .Days()
                .Including(Day.MONDAY | Day.TUESDAY | Day.WEDNESDAY | Day.THURSDAY | Day.FRIDAY)
                .Build();

            // Act.

            // Assert.
            Assert.Equal(new DateTime(2015, 1, 1), daily.Next(new DateTime(2014, 7, 3)));
            Assert.Equal(new DateTime(2015, 1, 2), daily.Next(new DateTime(2015, 1, 1)));
            Assert.Equal(new DateTime(2015, 1, 5), daily.Next(new DateTime(2015, 1, 2)));
            Assert.Equal(new DateTime(2015, 1, 6), daily.Next(new DateTime(2015, 1, 5)));
        }

        [Fact]
        public void Daily_EveryThirdDay_ExcludeWeekends()
        {
            // Arrange.
            IRecurring daily = Recurs
                .Starting(new DateTime(2015, 1, 1))
                .Every(3)
                .Days()
                .Including(Day.MONDAY | Day.TUESDAY | Day.WEDNESDAY | Day.THURSDAY | Day.FRIDAY)
                .Build();

            // Act.

            // Assert.
            Assert.Equal(new DateTime(2015, 1, 1), daily.Next(new DateTime(2014, 7, 3)));
            Assert.Equal(new DateTime(2015, 1, 6), daily.Next(new DateTime(2015, 1, 1)));
            Assert.Equal(new DateTime(2015, 1, 9), daily.Next(new DateTime(2015, 1, 6)));
            Assert.Equal(new DateTime(2015, 1, 14), daily.Next(new DateTime(2015, 1, 9)));
        }

    }
}
