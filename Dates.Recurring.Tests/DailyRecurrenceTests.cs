﻿using Dates.Recurring.Type;
using System;
using Xunit;

namespace Dates.Recurring.Tests
{
    public sealed class DailyRecurrenceTests
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

            Assert.Equal(new DateTime(2015, 1, 1), daily.Previous(new DateTime(2015, 1, 2)));
            Assert.Equal(new DateTime(2015, 1, 2), daily.Previous(new DateTime(2015, 1, 3)));
            Assert.Equal(new DateTime(2015, 1, 3), daily.Previous(new DateTime(2015, 1, 4)));
            Assert.Equal(new DateTime(2015, 1, 14), daily.Previous(new DateTime(2015, 1, 15)));
            Assert.Equal(new DateTime(2015, 1, 15), daily.Previous(new DateTime(2015, 1, 16)));
            Assert.Equal(new DateTime(2015, 1, 15), daily.Previous(new DateTime(2015, 1, 17)));

            Assert.Null(daily.Previous(new DateTime(2015, 1, 1)));
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

            Assert.Equal(new DateTime(2015, 1, 1), daily.Previous(new DateTime(2015, 1, 2)));
            Assert.Equal(new DateTime(2015, 1, 1), daily.Previous(new DateTime(2015, 1, 3)));
            Assert.Equal(new DateTime(2015, 1, 1), daily.Previous(new DateTime(2015, 1, 4)));
            Assert.Equal(new DateTime(2015, 1, 4), daily.Previous(new DateTime(2015, 1, 5)));
            Assert.Equal(new DateTime(2015, 1, 4), daily.Previous(new DateTime(2015, 1, 6)));
            Assert.Equal(new DateTime(2015, 1, 4), daily.Previous(new DateTime(2015, 1, 7)));
            Assert.Equal(new DateTime(2015, 1, 7), daily.Previous(new DateTime(2015, 1, 8)));
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

            Assert.Equal(new DateTime(2015, 1, 1), daily.Previous(new DateTime(2015, 1, 2)));
            Assert.Equal(new DateTime(2015, 1, 2), daily.Previous(new DateTime(2015, 1, 3)));
            Assert.Equal(new DateTime(2015, 1, 5), daily.Previous(new DateTime(2015, 1, 6)));
            Assert.Equal(new DateTime(2015, 1, 6), daily.Previous(new DateTime(2015, 1, 7)));
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

            Assert.Equal(new DateTime(2015, 1, 1), daily.Previous(new DateTime(2015, 1, 2)));
            Assert.Equal(new DateTime(2015, 1, 6), daily.Previous(new DateTime(2015, 1, 7)));
            Assert.Equal(new DateTime(2015, 1, 9), daily.Previous(new DateTime(2015, 1, 10)));
            Assert.Equal(new DateTime(2015, 1, 14), daily.Previous(new DateTime(2015, 1, 15)));
        }

        [Fact]
        public void Daily_EveryDay_EndingAfter()
        {
            // Arrange.
            IRecurring daily = Recurs
                .Starting(new DateTime(2015, 1, 1))
                .Every(1)
                .Days()
                .EndingAfter(5)
                .Build();
            
            // Act.

            // Assert.
            Assert.Equal(new DateTime(2015, 1, 2), daily.Next(new DateTime(2015, 1, 1)));
            Assert.Equal(new DateTime(2015, 1, 3), daily.Next(new DateTime(2015, 1, 2)));
            Assert.Equal(new DateTime(2015, 1, 4), daily.Next(new DateTime(2015, 1, 3)));
            Assert.Equal(new DateTime(2015, 1, 5), daily.Next(new DateTime(2015, 1, 4)));
            Assert.Equal(new DateTime(2015, 1, 6), daily.Next(new DateTime(2015, 1, 5)));

            Assert.Null(daily.Next(new DateTime(2015, 1, 6)));

            Assert.Equal(new DateTime(2015, 1, 1), daily.Previous(new DateTime(2015, 1, 2)));
            Assert.Equal(new DateTime(2015, 1, 2), daily.Previous(new DateTime(2015, 1, 3)));
            Assert.Equal(new DateTime(2015, 1, 3), daily.Previous(new DateTime(2015, 1, 4)));
            Assert.Equal(new DateTime(2015, 1, 4), daily.Previous(new DateTime(2015, 1, 5)));
            Assert.Equal(new DateTime(2015, 1, 5), daily.Previous(new DateTime(2015, 1, 6)));
            Assert.Equal(new DateTime(2015, 1, 5), daily.Previous(new DateTime(2015, 2, 6)));

            Assert.Null(daily.Previous(new DateTime(2015, 1, 1)));
        }

    }
}
