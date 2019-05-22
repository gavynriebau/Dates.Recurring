﻿using System;
using Dates.Recurring.Type;
using Xunit;

namespace Dates.Recurring.Tests
{
    public sealed class MonthlyRecurrenceTests
    {

        [Fact]
        public void Monthly_EveryMonth()
        {
            // Arrange.
            IRecurring monthly = Recurs
                .Starting(new DateTime(2015, 1, 1))
                .Every(1)
                .Months()
                .OnDay(24)
                .Ending(new DateTime(2016, 2, 4))
                .Build();

            // Act.

            // Assert.
            Assert.Equal(new DateTime(2015, 1, 24), monthly.Next(new DateTime(2014, 4, 8)));
            Assert.Equal(new DateTime(2015, 2, 24), monthly.Next(new DateTime(2015, 1, 24)));
            Assert.Equal(new DateTime(2015, 2, 24), monthly.Next(new DateTime(2015, 2, 23)));
            Assert.Equal(new DateTime(2015, 3, 24), monthly.Next(new DateTime(2015, 2, 24)));
            Assert.Equal(new DateTime(2015, 3, 24), monthly.Next(new DateTime(2015, 2, 25)));
            Assert.Equal(new DateTime(2015, 6, 24), monthly.Next(new DateTime(2015, 6, 3)));

            Assert.Null(monthly.Next(new DateTime(2016, 6, 3)));

            Assert.Equal(new DateTime(2015, 1, 24), monthly.Previous(new DateTime(2015, 1, 25)));
            Assert.Equal(new DateTime(2015, 1, 24), monthly.Previous(new DateTime(2015, 2, 24)));
            Assert.Equal(new DateTime(2015, 2, 24), monthly.Previous(new DateTime(2015, 2, 25)));
            Assert.Equal(new DateTime(2015, 2, 24), monthly.Previous(new DateTime(2015, 3, 24)));
            Assert.Equal(new DateTime(2015, 2, 24), monthly.Previous(new DateTime(2015, 2, 25)));
            Assert.Equal(new DateTime(2015, 3, 24), monthly.Previous(new DateTime(2015, 3, 25)));
            Assert.Equal(new DateTime(2015, 3, 24), monthly.Previous(new DateTime(2015, 4, 24)));
            Assert.Equal(new DateTime(2015, 6, 24), monthly.Previous(new DateTime(2015, 6, 25)));

            Assert.Null(monthly.Previous(new DateTime(2015, 1, 24)));
        }

        [Fact]
        public void Monthly_EveryThirdMonth()
        {
            // Arrange.
            IRecurring monthly = Recurs
                .Starting(new DateTime(2015, 1, 1))
                .Every(3)
                .Months()
                .OnDay(24)
                .Ending(new DateTime(2016, 2, 4))
                .Build();

            // Act.

            // Assert.
            Assert.Equal(new DateTime(2015, 1, 24), monthly.Next(new DateTime(2014, 2, 1)));
            Assert.Equal(new DateTime(2015, 4, 24), monthly.Next(new DateTime(2015, 1, 24)));
            Assert.Equal(new DateTime(2015, 4, 24), monthly.Next(new DateTime(2015, 1, 25)));
            Assert.Equal(new DateTime(2015, 4, 24), monthly.Next(new DateTime(2015, 2, 1)));
            Assert.Equal(new DateTime(2015, 4, 24), monthly.Next(new DateTime(2015, 2, 17)));
            Assert.Equal(new DateTime(2015, 4, 24), monthly.Next(new DateTime(2015, 4, 23)));
            Assert.Equal(new DateTime(2015, 7, 24), monthly.Next(new DateTime(2015, 4, 24)));
            
            Assert.Null(monthly.Next(new DateTime(2016, 6, 3)));

            Assert.Equal(new DateTime(2015, 1, 24), monthly.Previous(new DateTime(2015, 1, 25)));
            Assert.Equal(new DateTime(2015, 4, 24), monthly.Previous(new DateTime(2015, 4, 25)));
            Assert.Equal(new DateTime(2015, 4, 24), monthly.Previous(new DateTime(2015, 5, 25)));
            Assert.Equal(new DateTime(2015, 4, 24), monthly.Previous(new DateTime(2015, 6, 25)));
            Assert.Equal(new DateTime(2015, 4, 24), monthly.Previous(new DateTime(2015, 7, 23)));
            Assert.Equal(new DateTime(2015, 4, 24), monthly.Previous(new DateTime(2015, 7, 24)));
            Assert.Equal(new DateTime(2015, 7, 24), monthly.Previous(new DateTime(2015, 7, 25)));
            
            Assert.Null(monthly.Previous(new DateTime(2015, 1, 24)));
        }

        [Fact]
        public void Monthly_EveryMonth_DifferentDaysInMonths()
        {
            // Arrange.
            IRecurring monthly = Recurs
                .Starting(new DateTime(2015, 1, 1))
                .Every(1)
                .Months()
                .OnDay(31)
                .Ending(new DateTime(2016, 2, 4))
                .Build();

            // Act.

            // Assert.
            Assert.Equal(new DateTime(2015, 1, 31), monthly.Next(new DateTime(2014, 2, 1)));
            Assert.Equal(new DateTime(2015, 1, 31), monthly.Next(new DateTime(2015, 1, 30)));
            Assert.Equal(new DateTime(2015, 2, 28), monthly.Next(new DateTime(2015, 1, 31)));
            Assert.Equal(new DateTime(2015, 2, 28), monthly.Next(new DateTime(2015, 2, 27)));
            Assert.Equal(new DateTime(2015, 3, 31), monthly.Next(new DateTime(2015, 2, 28)));
            Assert.Equal(new DateTime(2015, 4, 30), monthly.Next(new DateTime(2015, 3, 31)));

            Assert.Null(monthly.Next(new DateTime(2016, 6, 3)));

            Assert.Equal(new DateTime(2015, 1, 31), monthly.Previous(new DateTime(2015, 2, 28)));
            Assert.Equal(new DateTime(2015, 1, 31), monthly.Previous(new DateTime(2015, 2, 1)));
            Assert.Equal(new DateTime(2015, 2, 28), monthly.Previous(new DateTime(2015, 3, 1)));
            Assert.Equal(new DateTime(2015, 2, 28), monthly.Previous(new DateTime(2015, 3, 15)));
            Assert.Equal(new DateTime(2015, 3, 31), monthly.Previous(new DateTime(2015, 4, 1)));
            Assert.Equal(new DateTime(2015, 4, 30), monthly.Previous(new DateTime(2015, 5, 1)));
            
            Assert.Null(monthly.Previous(new DateTime(2015, 1, 31)));
        }

        [Fact]
        public void Monthly_EveryMonth_Ordinal()
        {
            // Arrange.
            IRecurring monthly = Recurs
                .Starting(new DateTime(2018, 1, 1)) // Monday
                .Every(1)
                .Months()
                .OnOrdinalWeek(Ordinal.SECOND)
                .OnDay(DayOfWeek.Friday)
                .Ending(new DateTime(2018, 12, 25))
                .Build();

            // Act.

            // Assert.
            Assert.Equal(new DateTime(2018, 1, 12), monthly.Next(new DateTime(2017, 1, 1)));
            Assert.Equal(new DateTime(2018, 1, 12), monthly.Next(new DateTime(2018, 1, 1)));
            Assert.Equal(new DateTime(2018, 2, 9), monthly.Next(new DateTime(2018, 2, 1)));
            Assert.Equal(new DateTime(2018, 9, 14), monthly.Next(new DateTime(2018, 9, 1)));

            Assert.Null(monthly.Next(new DateTime(2020, 2, 1)));

            Assert.Equal(new DateTime(2018, 1, 12), monthly.Previous(new DateTime(2018, 1, 13)));
            Assert.Equal(new DateTime(2018, 1, 12), monthly.Previous(new DateTime(2018, 2, 9)));
            Assert.Equal(new DateTime(2018, 2, 9), monthly.Previous(new DateTime(2018, 2, 10)));
            Assert.Equal(new DateTime(2018, 9, 14), monthly.Previous(new DateTime(2018, 9, 15)));
            
            Assert.Null(monthly.Previous(new DateTime(2018, 1, 12)));
        }

        [Fact]
        public void Monthly_EveryThirdMonth_Ordinal()
        {
            // Arrange.
            IRecurring monthly = Recurs
                .Starting(new DateTime(2018, 1, 1)) // Monday
                .Every(3)
                .Months()
                .OnOrdinalWeek(Ordinal.SECOND)
                .OnDay(DayOfWeek.Friday)
                .Ending(new DateTime(2018, 12, 25))
                .Build();

            // Act.

            // Assert.
            Assert.Equal(new DateTime(2018, 1, 12), monthly.Next(new DateTime(2017, 1, 1)));
            Assert.Equal(new DateTime(2018, 1, 12), monthly.Next(new DateTime(2018, 1, 1)));
            Assert.Equal(new DateTime(2018, 4, 13), monthly.Next(new DateTime(2018, 1, 12)));
            Assert.Equal(new DateTime(2018, 7, 13), monthly.Next(new DateTime(2018, 7, 1)));

            Assert.Null(monthly.Next(new DateTime(2020, 2, 1)));

            Assert.Equal(new DateTime(2018, 1, 12), monthly.Previous(new DateTime(2018, 1, 13)));
            Assert.Equal(new DateTime(2018, 1, 12), monthly.Previous(new DateTime(2018, 4, 13)));
            Assert.Equal(new DateTime(2018, 4, 13), monthly.Previous(new DateTime(2018, 4, 14)));
            Assert.Equal(new DateTime(2018, 4, 13), monthly.Previous(new DateTime(2018, 7, 13)));

            Assert.Null(monthly.Previous(new DateTime(2018, 1, 12)));
        }

        [Fact]
        public void Monthly_EveryMonth_Ordinal_LastWeek()
        {
            // Arrange.
            IRecurring monthly = Recurs
                .Starting(new DateTime(2018, 1, 1)) // Monday
                .Every(1)
                .Months()
                .OnOrdinalWeek(Ordinal.LAST)
                .OnDay(DayOfWeek.Wednesday)
                .Ending(new DateTime(2018, 12, 25))
                .Build();

            // Act.

            // Assert.
            Assert.Equal(new DateTime(2018, 1, 31), monthly.Next(new DateTime(2017, 1, 1)));
            Assert.Equal(new DateTime(2018, 1, 31), monthly.Next(new DateTime(2018, 1, 1)));
            Assert.Equal(new DateTime(2018, 2, 28), monthly.Next(new DateTime(2018, 1, 31)));
            Assert.Equal(new DateTime(2018, 2, 28), monthly.Next(new DateTime(2018, 2, 1)));
            Assert.Equal(new DateTime(2018, 4, 25), monthly.Next(new DateTime(2018, 4, 1)));

            Assert.Null(monthly.Next(new DateTime(2020, 2, 1)));

            Assert.Equal(new DateTime(2018, 1, 31), monthly.Previous(new DateTime(2018, 2, 1)));
            Assert.Equal(new DateTime(2018, 1, 31), monthly.Previous(new DateTime(2018, 2, 28)));
            Assert.Equal(new DateTime(2018, 2, 28), monthly.Previous(new DateTime(2018, 3, 1)));
            Assert.Equal(new DateTime(2018, 3, 28), monthly.Previous(new DateTime(2018, 4, 25)));
            Assert.Equal(new DateTime(2018, 4, 25), monthly.Previous(new DateTime(2018, 4, 26)));

            Assert.Null(monthly.Previous(new DateTime(2018, 1, 31)));
        }

        [Fact]
        public void Monthly_EveryLastMonth_Ordinal_SameDay()
        {
            // Arrange.
            IRecurring monthly = Recurs
                .Starting(new DateTime(2018, 12, 25, 11, 00, 00)) // Monday
                .Every(1)
                .Months()
                .OnOrdinalWeek(Ordinal.FOURTH)
                .OnDay(DayOfWeek.Tuesday)
                .Ending(new DateTime(2019, 12, 26))
                .Build();

            // Act.

            // Assert.
            Assert.Equal(new DateTime(2018,12,25, 11,00,00 ), monthly.Next(new DateTime(2018, 12, 25, 09, 00 ,00)));
        }
    }
}

