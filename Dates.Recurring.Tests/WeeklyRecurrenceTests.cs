using Xunit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dates.Recurring.Type;

namespace Dates.Recurring.Tests
{
    public class WeeklyRecurrenceTests
    {
        [Fact]
        public void Weekly_EveryWeek()
        {
            // Arrange.
            IRecurring weekly = Recurs
                .Starting(new DateTime(2015, 1, 1))
                .Every(1)
                .Weeks()
                .OnDays(Day.TUESDAY | Day.FRIDAY)
                .Ending(new DateTime(2015, 2, 19))
                .Build();

            // Act.

            // Assert.
            Assert.Equal(new DateTime(2015, 1, 2), weekly.Next(new DateTime(2014, 1, 1)));
            Assert.Equal(new DateTime(2015, 1, 6), weekly.Next(new DateTime(2015, 1, 2)));
            Assert.Equal(new DateTime(2015, 1, 9), weekly.Next(new DateTime(2015, 1, 6)));
            Assert.Equal(new DateTime(2015, 1, 13), weekly.Next(new DateTime(2015, 1, 9)));
            Assert.Equal(new DateTime(2015, 1, 16), weekly.Next(new DateTime(2015, 1, 13)));
        }

        [Fact]
        public void Weekly_EveryThirdWeek()
        {
            // Arrange.
            IRecurring weekly = Recurs
                .Starting(new DateTime(2015, 1, 1))
                .Every(3)
                .Weeks()
                .OnDays(Day.TUESDAY | Day.FRIDAY)
                .Ending(new DateTime(2015, 2, 19))
                .Build();

            // Act.

            // Assert.
            Assert.Equal(new DateTime(2015, 1, 2), weekly.Next(new DateTime(2014, 1, 1)));
            Assert.Equal(new DateTime(2015, 1, 20), weekly.Next(new DateTime(2015, 1, 2)));
            Assert.Equal(new DateTime(2015, 1, 23), weekly.Next(new DateTime(2015, 1, 21)));
            Assert.Equal(new DateTime(2015, 2, 10), weekly.Next(new DateTime(2015, 1, 23)));
            Assert.Equal(new DateTime(2015, 2, 10), weekly.Next(new DateTime(2015, 1, 24)));
            Assert.Equal(new DateTime(2015, 2, 10), weekly.Next(new DateTime(2015, 1, 27)));
            Assert.Equal(new DateTime(2015, 2, 13), weekly.Next(new DateTime(2015, 2, 10)));
        }

        [Fact]
        public void Weekly_EveryWeek_TwoDaysAfterDateTime()
        {
            // Arrange.
            DateTime startDate = new DateTime(2015, 1, 1);

            IRecurring weekly = Recurs
                .Starting(startDate)
                .Every(1)
                .Weeks()
                .OnDay(startDate.AddDays(2).DayOfWeek)
                .Ending(new DateTime(2015, 2, 19))
                .Build();

            // Act.

            // Assert.
            Assert.Equal(new DateTime(2015, 1, 3), weekly.Next(new DateTime(2014, 1, 1)));
            Assert.Equal(new DateTime(2015, 1, 3), weekly.Next(new DateTime(2015, 1, 2)));
            Assert.Equal(new DateTime(2015, 1, 10), weekly.Next(new DateTime(2015, 1, 6)));
            Assert.Equal(new DateTime(2015, 1, 10), weekly.Next(new DateTime(2015, 1, 9)));
            Assert.Equal(new DateTime(2015, 1, 17), weekly.Next(new DateTime(2015, 1, 13)));
            Assert.Null(weekly.Next(new DateTime(2015, 2, 19)));
        }
    }
}
