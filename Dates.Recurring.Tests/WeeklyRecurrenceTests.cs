using Xunit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dates.Recurring.Type;

namespace Dates.Recurring.Tests
{
    public sealed class WeeklyRecurrenceTests
    {
        [Fact]
        public void Weekly_EveryWeek()
        {
            // Arrange.
            IRecurring weekly = Recurs
                .Starting(new DateTime(2015, 1, 1)) // Thursday
                .Every(1)
                .Weeks()
                .OnDays(Day.TUESDAY | Day.FRIDAY)
                .Ending(new DateTime(2015, 1, 19)) // Thursday
                .Build();

            // Act.

            // Assert.
            Assert.Equal(new DateTime(2015, 1, 2), weekly.Next(new DateTime(2014, 1, 1)));
            Assert.Equal(new DateTime(2015, 1, 6), weekly.Next(new DateTime(2015, 1, 2)));
            Assert.Equal(new DateTime(2015, 1, 9), weekly.Next(new DateTime(2015, 1, 6)));
            Assert.Equal(new DateTime(2015, 1, 13), weekly.Next(new DateTime(2015, 1, 9)));
            Assert.Equal(new DateTime(2015, 1, 16), weekly.Next(new DateTime(2015, 1, 13)));

            Assert.Null(weekly.Next(new DateTime(2015, 1, 16)));

            Assert.Equal(new DateTime(2015, 1, 2), weekly.Previous(new DateTime(2015, 1, 6)));
            Assert.Equal(new DateTime(2015, 1, 6), weekly.Previous(new DateTime(2015, 1, 9)));
            Assert.Equal(new DateTime(2015, 1, 9), weekly.Previous(new DateTime(2015, 1, 13)));
            Assert.Equal(new DateTime(2015, 1, 13), weekly.Previous(new DateTime(2015, 1, 16)));
            Assert.Equal(new DateTime(2015, 1, 16), weekly.Previous(new DateTime(2015, 1, 19)));
            Assert.Equal(new DateTime(2015, 1, 16), weekly.Previous(new DateTime(2015, 1, 20)));
            Assert.Equal(new DateTime(2015, 1, 16), weekly.Previous(new DateTime(2015, 1, 21)));

            Assert.Null(weekly.Previous(new DateTime(2015, 1, 2)));
            Assert.Null(weekly.Previous(new DateTime(2015, 1, 1)));
            Assert.Null(weekly.Previous(new DateTime(2014, 1, 1)));
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

            Assert.Equal(new DateTime(2015, 1, 2), weekly.Previous(new DateTime(2015, 1, 3)));
            Assert.Equal(new DateTime(2015, 1, 20), weekly.Previous(new DateTime(2015, 1, 21)));
            Assert.Equal(new DateTime(2015, 1, 23), weekly.Previous(new DateTime(2015, 1, 24)));
            Assert.Equal(new DateTime(2015, 2, 10), weekly.Previous(new DateTime(2015, 2, 11)));
            Assert.Equal(new DateTime(2015, 2, 10), weekly.Previous(new DateTime(2015, 2, 13)));
            Assert.Equal(new DateTime(2015, 2, 13), weekly.Previous(new DateTime(2015, 2, 14)));
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
                .OnDay(DayOfWeek.Saturday)
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

            Assert.Equal(new DateTime(2015, 1, 3), weekly.Previous(new DateTime(2015, 1, 4)));
            Assert.Equal(new DateTime(2015, 1, 3), weekly.Previous(new DateTime(2015, 1, 10)));
            Assert.Equal(new DateTime(2015, 1, 10), weekly.Previous(new DateTime(2015, 1, 11)));
            Assert.Equal(new DateTime(2015, 1, 10), weekly.Previous(new DateTime(2015, 1, 17)));
            Assert.Equal(new DateTime(2015, 1, 17), weekly.Previous(new DateTime(2015, 1, 18)));
            
            Assert.Null(weekly.Previous(new DateTime(2015, 1, 3)));
        }

        [Fact]
        public void Weekly_Every2Weeks_SatSun()
        {
            // Arrange.
            DateTime startDate = new DateTime(2018, 2, 22);

            IRecurring weekly = Recurs
                .Starting(startDate)
                .Every(2)   
                .Weeks()
                .FirstDayOfWeek(DayOfWeek.Monday)
                .OnDays(Day.SATURDAY | Day.SUNDAY)
                .Ending(new DateTime(2018, 8, 28))
                .Build();

            // Act.

            // Assert.
            Assert.Equal(new DateTime(2018, 2, 24), weekly.Next(new DateTime(2018, 2, 23)));
            Assert.Equal(new DateTime(2018, 2, 25), weekly.Next(new DateTime(2018, 2, 24)));

            Assert.Equal(new DateTime(2018, 3, 10), weekly.Next(new DateTime(2018, 3, 2)));
            Assert.Equal(new DateTime(2018, 3, 10), weekly.Next(new DateTime(2018, 3, 3)));

            Assert.Equal(new DateTime(2018, 3, 10), weekly.Next(new DateTime(2018, 3, 9)));
            Assert.Equal(new DateTime(2018, 3, 11), weekly.Next(new DateTime(2018, 3, 10)));
            
            Assert.Null(weekly.Next(new DateTime(2018, 8, 28)));

            Assert.Equal(new DateTime(2018, 2, 24), weekly.Previous(new DateTime(2018, 2, 25)));
            Assert.Equal(new DateTime(2018, 2, 25), weekly.Previous(new DateTime(2018, 3, 10)));

            Assert.Equal(new DateTime(2018, 3, 10), weekly.Previous(new DateTime(2018, 3, 11)));
            Assert.Equal(new DateTime(2018, 3, 11), weekly.Previous(new DateTime(2018, 3, 12)));
            
            Assert.Null(weekly.Previous(new DateTime(2018, 2, 24)));
        }


        [Fact]
        public void Weekly_Every2Weeks_SunMon()
        {
            // Arrange.
            DateTime startDate = new DateTime(2018, 2, 22);

            IRecurring weekly = Recurs
                .Starting(startDate)                
                .Every(2)
                .Weeks()
                .FirstDayOfWeek(DayOfWeek.Monday)
                .OnDays(Day.SUNDAY | Day.MONDAY)
                .Ending(new DateTime(2018, 8, 28))
                .Build();

            // Act.

            // Assert.
            Assert.Equal(new DateTime(2018, 2, 25), weekly.Next(new DateTime(2018, 2, 24)));
            Assert.Equal(new DateTime(2018, 3, 5), weekly.Next(new DateTime(2018, 2, 25)));

            Assert.Equal(new DateTime(2018, 3, 5), weekly.Next(new DateTime(2018, 3, 3)));
            Assert.Equal(new DateTime(2018, 3, 11), weekly.Next(new DateTime(2018, 3, 5)));

            Assert.Equal(new DateTime(2018, 3, 19), weekly.Next(new DateTime(2018, 3, 11)));
            Assert.Equal(new DateTime(2018, 3, 25), weekly.Next(new DateTime(2018, 3, 20)));

            Assert.Equal(new DateTime(2018, 4, 2), weekly.Next(new DateTime(2018, 4, 1)));
            Assert.Equal(new DateTime(2018, 4, 8), weekly.Next(new DateTime(2018, 4, 3)));

            Assert.Null(weekly.Next(new DateTime(2018, 8, 28)));

            Assert.Equal(new DateTime(2018, 2, 25), weekly.Previous(new DateTime(2018, 2, 26)));
            Assert.Equal(new DateTime(2018, 3, 5), weekly.Previous(new DateTime(2018, 3, 6)));
            Assert.Equal(new DateTime(2018, 3, 5), weekly.Previous(new DateTime(2018, 3, 11)));
            Assert.Equal(new DateTime(2018, 3, 11), weekly.Previous(new DateTime(2018, 3, 12)));
            Assert.Equal(new DateTime(2018, 3, 19), weekly.Previous(new DateTime(2018, 3, 25)));
            Assert.Equal(new DateTime(2018, 3, 25), weekly.Previous(new DateTime(2018, 4, 2)));
            Assert.Equal(new DateTime(2018, 4, 2), weekly.Previous(new DateTime(2018, 4, 3)));
            Assert.Equal(new DateTime(2018, 4, 8), weekly.Previous(new DateTime(2018, 4, 9)));

            Assert.Null(weekly.Previous(new DateTime(2018, 2, 25)));
        }
    }
}
