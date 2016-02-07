using Xunit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dates.Recurring.Type;

namespace Dates.Recurring.Tests
{
    public class YearlyRecurrenceTests
    {

        [Fact]
        public void Yearly_EveryYear()
        {
            // Arrange.
            IRecurring yearly = Recurs
                .Starting(new DateTime(2015, 1, 1))
                .Every(1)
                .Years()
                .OnDay(24)
                .OnMonths(Month.JANUARY | Month.FEBRUARY | Month.AUGUST)
                .Ending(new DateTime(2020, 1, 1))
                .Build();

            // Act.

            // Assert.
            Assert.Equal(new DateTime(2015, 1, 24), yearly.Next(new DateTime(2014, 1, 1)));
            Assert.Equal(new DateTime(2015, 1, 24), yearly.Next(new DateTime(2015, 1, 1)));
            Assert.Equal(new DateTime(2015, 1, 24), yearly.Next(new DateTime(2015, 1, 23)));
            Assert.Equal(new DateTime(2015, 2, 24), yearly.Next(new DateTime(2015, 1, 24)));
            Assert.Equal(new DateTime(2015, 2, 24), yearly.Next(new DateTime(2015, 1, 25)));
            Assert.Equal(new DateTime(2015, 2, 24), yearly.Next(new DateTime(2015, 2, 1)));
            Assert.Equal(new DateTime(2015, 2, 24), yearly.Next(new DateTime(2015, 2, 23)));
            Assert.Equal(new DateTime(2015, 8, 24), yearly.Next(new DateTime(2015, 2, 24)));
            Assert.Equal(new DateTime(2015, 8, 24), yearly.Next(new DateTime(2015, 3, 24)));
            Assert.Equal(new DateTime(2015, 8, 24), yearly.Next(new DateTime(2015, 4, 24)));
            Assert.Equal(new DateTime(2015, 8, 24), yearly.Next(new DateTime(2015, 5, 24)));
            Assert.Equal(new DateTime(2015, 8, 24), yearly.Next(new DateTime(2015, 6, 24)));
            Assert.Equal(new DateTime(2015, 8, 24), yearly.Next(new DateTime(2015, 7, 24)));
            Assert.Equal(new DateTime(2016, 1, 24), yearly.Next(new DateTime(2015, 8, 24)));
            Assert.Equal(new DateTime(2016, 2, 24), yearly.Next(new DateTime(2016, 1, 24)));
            Assert.Null(yearly.Next(new DateTime(2020, 1, 1)));
        }

        [Fact]
        public void Yearly_EveryThirdYear()
        {
            // Arrange.
            IRecurring yearly = Recurs
                .Starting(new DateTime(2015, 1, 1))
                .Every(3)
                .Years()
                .OnDay(24)
                .OnMonths(Month.JANUARY | Month.FEBRUARY | Month.AUGUST)
                .Ending(new DateTime(2020, 1, 1))
                .Build();

            // Act.

            // Assert.
            Assert.Equal(new DateTime(2015, 1, 24), yearly.Next(new DateTime(2014, 1, 1)));
            Assert.Equal(new DateTime(2015, 1, 24), yearly.Next(new DateTime(2015, 1, 1)));
            Assert.Equal(new DateTime(2015, 1, 24), yearly.Next(new DateTime(2015, 1, 23)));
            Assert.Equal(new DateTime(2015, 2, 24), yearly.Next(new DateTime(2015, 1, 24)));
            Assert.Equal(new DateTime(2015, 2, 24), yearly.Next(new DateTime(2015, 1, 25)));
            Assert.Equal(new DateTime(2015, 2, 24), yearly.Next(new DateTime(2015, 2, 1)));
            Assert.Equal(new DateTime(2015, 2, 24), yearly.Next(new DateTime(2015, 2, 23)));
            Assert.Equal(new DateTime(2015, 8, 24), yearly.Next(new DateTime(2015, 2, 24)));
            Assert.Equal(new DateTime(2015, 8, 24), yearly.Next(new DateTime(2015, 3, 24)));
            Assert.Equal(new DateTime(2015, 8, 24), yearly.Next(new DateTime(2015, 4, 24)));
            Assert.Equal(new DateTime(2015, 8, 24), yearly.Next(new DateTime(2015, 5, 24)));
            Assert.Equal(new DateTime(2015, 8, 24), yearly.Next(new DateTime(2015, 6, 24)));
            Assert.Equal(new DateTime(2015, 8, 24), yearly.Next(new DateTime(2015, 7, 24)));
            Assert.Equal(new DateTime(2018, 1, 24), yearly.Next(new DateTime(2015, 8, 24)));
            Assert.Equal(new DateTime(2018, 2, 24), yearly.Next(new DateTime(2018, 1, 24)));
            Assert.Equal(new DateTime(2018, 8, 24), yearly.Next(new DateTime(2018, 2, 24)));
            Assert.Equal(new DateTime(2018, 8, 24), yearly.Next(new DateTime(2018, 6, 11)));
            Assert.Null(yearly.Next(new DateTime(2020, 1, 1)));
        }

        [Fact]
        public void Yearly_EveryYear_DifferentDaysInMonth()
        {
            // Arrange.
            IRecurring yearly = Recurs
                .Starting(new DateTime(2015, 1, 1))
                .Every(1)
                .Years()
                .OnDay(31)
                .OnMonths(Month.JANUARY | Month.FEBRUARY | Month.AUGUST)
                .Ending(new DateTime(2020, 1, 1))
                .Build();

            // Act.

            // Assert.
            Assert.Equal(new DateTime(2015, 1, 31), yearly.Next(new DateTime(2014, 1, 1)));
            Assert.Equal(new DateTime(2015, 1, 31), yearly.Next(new DateTime(2015, 1, 6)));
            Assert.Equal(new DateTime(2015, 2, 28), yearly.Next(new DateTime(2015, 1, 31)));
            Assert.Equal(new DateTime(2015, 2, 28), yearly.Next(new DateTime(2015, 2, 27)));
            Assert.Equal(new DateTime(2015, 8, 31), yearly.Next(new DateTime(2015, 2, 28)));
            Assert.Null(yearly.Next(new DateTime(2020, 1, 1)));
        }

    }
}

