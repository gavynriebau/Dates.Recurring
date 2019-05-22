using System;
using Dates.Recurring.Type;
using Xunit;

namespace Dates.Recurring.Tests
{
    public sealed class YearlyRecurrenceTests
    {
        [Fact]
        public void Yearly_EveryYear()
        {
            // Arrange.
            IRecurring yearly = Recurs
                .Starting(new DateTime(2015, 1, 1, 11, 00 ,00))
                .Every(1)
                .Years()
                .OnDay(24)
                .OnMonths(Month.JANUARY | Month.FEBRUARY | Month.AUGUST)
                .Ending(new DateTime(2020, 1, 1))
                .Build();

            // Act.

            // Assert.
            Assert.Equal(new DateTime(2015, 1, 24,11,00,00), yearly.Next(new DateTime(2014, 1, 1)));
            Assert.Equal(new DateTime(2015, 1, 24,11,00,00), yearly.Next(new DateTime(2015, 1, 1)));
            Assert.Equal(new DateTime(2015, 1, 24,11,00,00), yearly.Next(new DateTime(2015, 1, 23)));
            Assert.Equal(new DateTime(2015, 1, 24,11,00,00), yearly.Next(new DateTime(2015, 1, 24)));
            Assert.Equal(new DateTime(2015, 2, 24,11,00,00), yearly.Next(new DateTime(2015, 1, 25)));
            Assert.Equal(new DateTime(2015, 2, 24,11,00,00), yearly.Next(new DateTime(2015, 2, 1)));
            Assert.Equal(new DateTime(2015, 2, 24,11,00,00), yearly.Next(new DateTime(2015, 2, 23)));

            Assert.Equal(new DateTime(2015, 2, 24,11,00,00), yearly.Next(new DateTime(2015, 2, 24)));

            Assert.Equal(new DateTime(2015, 8, 24,11,00,00), yearly.Next(new DateTime(2015, 3, 24)));
            Assert.Equal(new DateTime(2015, 8, 24,11,00,00), yearly.Next(new DateTime(2015, 4, 24)));
            Assert.Equal(new DateTime(2015, 8, 24,11,00,00), yearly.Next(new DateTime(2015, 5, 24)));
            Assert.Equal(new DateTime(2015, 8, 24,11,00,00), yearly.Next(new DateTime(2015, 6, 24)));
            Assert.Equal(new DateTime(2015, 8, 24,11,00,00), yearly.Next(new DateTime(2015, 7, 24)));
            Assert.Equal(new DateTime(2015, 8, 24,11,00,00), yearly.Next(new DateTime(2015, 8, 24)));
            Assert.Equal(new DateTime(2016, 1, 24,11,00,00), yearly.Next(new DateTime(2016, 1, 24)));

            Assert.Null(yearly.Next(new DateTime(2020, 1, 1,11,00,00)));

            Assert.Equal(new DateTime(2015, 1, 24,11,00,00), yearly.Previous(new DateTime(2015, 1, 25)));
            Assert.Equal(new DateTime(2015, 1, 24,11,00,00), yearly.Previous(new DateTime(2015, 2, 23)));
            Assert.Equal(new DateTime(2015, 1, 24,11,00,00), yearly.Previous(new DateTime(2015, 2, 24)));
            Assert.Equal(new DateTime(2015, 2, 24,11,00,00), yearly.Previous(new DateTime(2015, 2, 25)));
            Assert.Equal(new DateTime(2015, 2, 24,11,00,00), yearly.Previous(new DateTime(2015, 3, 25)));
            Assert.Equal(new DateTime(2015, 2, 24,11,00,00), yearly.Previous(new DateTime(2015, 4, 25)));
            Assert.Equal(new DateTime(2015, 2, 24,11,00,00), yearly.Previous(new DateTime(2015, 7, 25)));
            Assert.Equal(new DateTime(2015, 8, 24,11,00,00), yearly.Previous(new DateTime(2015, 8, 25)));
            Assert.Equal(new DateTime(2015, 8, 24,11,00,00), yearly.Previous(new DateTime(2015, 9, 25)));
            Assert.Equal(new DateTime(2015, 8, 24,11,00,00), yearly.Previous(new DateTime(2015, 10, 25)));
            Assert.Equal(new DateTime(2015, 8, 24,11,00,00), yearly.Previous(new DateTime(2015, 12, 25)));
            Assert.Equal(new DateTime(2015, 8, 24,11,00,00), yearly.Previous(new DateTime(2016, 1, 1)));
            Assert.Equal(new DateTime(2015, 8, 24,11,00,00), yearly.Previous(new DateTime(2016, 1, 24)));
            Assert.Equal(new DateTime(2016, 1, 24,11,00,00), yearly.Previous(new DateTime(2016, 1, 25)));
            Assert.Equal(new DateTime(2016, 2, 24,11,00,00), yearly.Previous(new DateTime(2016, 2, 25)));

            Assert.Null(yearly.Previous(new DateTime(2015, 1, 24,11,00,00)));
            Assert.Null(yearly.Previous(new DateTime(2015, 1, 1,11,00,00)));
            Assert.Null(yearly.Previous(new DateTime(2014, 1, 24,11,00,00)));
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
            Assert.Equal(new DateTime(2015, 1, 24), yearly.Next(new DateTime(2015, 1, 24)));
            Assert.Equal(new DateTime(2015, 2, 24), yearly.Next(new DateTime(2015, 1, 25)));
            Assert.Equal(new DateTime(2015, 2, 24), yearly.Next(new DateTime(2015, 2, 1)));
            Assert.Equal(new DateTime(2015, 2, 24), yearly.Next(new DateTime(2015, 2, 23)));
            Assert.Equal(new DateTime(2015, 2, 24), yearly.Next(new DateTime(2015, 2, 24)));
            Assert.Equal(new DateTime(2015, 8, 24), yearly.Next(new DateTime(2015, 3, 24)));
            Assert.Equal(new DateTime(2015, 8, 24), yearly.Next(new DateTime(2015, 4, 24)));
            Assert.Equal(new DateTime(2015, 8, 24), yearly.Next(new DateTime(2015, 5, 24)));
            Assert.Equal(new DateTime(2015, 8, 24), yearly.Next(new DateTime(2015, 6, 24)));
            Assert.Equal(new DateTime(2015, 8, 24), yearly.Next(new DateTime(2015, 7, 24)));
            Assert.Equal(new DateTime(2015, 8, 24), yearly.Next(new DateTime(2015, 8, 24)));
            Assert.Equal(new DateTime(2018, 1, 24), yearly.Next(new DateTime(2018, 1, 24)));
            Assert.Equal(new DateTime(2018, 2, 24), yearly.Next(new DateTime(2018, 2, 24)));
            Assert.Equal(new DateTime(2018, 8, 24), yearly.Next(new DateTime(2018, 6, 11)));

            Assert.Null(yearly.Next(new DateTime(2020, 1, 1)));

            Assert.Equal(new DateTime(2015, 1, 24), yearly.Previous(new DateTime(2015, 1, 25)));
            Assert.Equal(new DateTime(2015, 1, 24), yearly.Previous(new DateTime(2015, 2, 23)));
            Assert.Equal(new DateTime(2015, 1, 24), yearly.Previous(new DateTime(2015, 2, 24)));
            Assert.Equal(new DateTime(2015, 2, 24), yearly.Previous(new DateTime(2015, 2, 25)));
            Assert.Equal(new DateTime(2015, 2, 24), yearly.Previous(new DateTime(2015, 3, 25)));
            Assert.Equal(new DateTime(2015, 2, 24), yearly.Previous(new DateTime(2015, 8, 23)));
            Assert.Equal(new DateTime(2015, 2, 24), yearly.Previous(new DateTime(2015, 8, 24)));
            Assert.Equal(new DateTime(2015, 8, 24), yearly.Previous(new DateTime(2015, 8, 25)));
            Assert.Equal(new DateTime(2015, 8, 24), yearly.Previous(new DateTime(2015, 9, 25)));
            Assert.Equal(new DateTime(2015, 8, 24), yearly.Previous(new DateTime(2015, 10, 25)));
            Assert.Equal(new DateTime(2015, 8, 24), yearly.Previous(new DateTime(2016, 8, 25)));
            Assert.Equal(new DateTime(2015, 8, 24), yearly.Previous(new DateTime(2017, 8, 25)));
            Assert.Equal(new DateTime(2015, 8, 24), yearly.Previous(new DateTime(2018, 1, 24)));
            Assert.Equal(new DateTime(2018, 1, 24), yearly.Previous(new DateTime(2018, 1, 25)));
            Assert.Equal(new DateTime(2018, 2, 24), yearly.Previous(new DateTime(2018, 2, 25)));
            Assert.Equal(new DateTime(2018, 8, 24), yearly.Previous(new DateTime(2018, 8, 25)));
            Assert.Equal(new DateTime(2018, 8, 24), yearly.Previous(new DateTime(2020, 8, 25)));

            Assert.Null(yearly.Previous(new DateTime(2015, 1, 24)));
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
            Assert.Equal(new DateTime(2015, 1, 31), yearly.Next(new DateTime(2015, 1, 31)));
            Assert.Equal(new DateTime(2015, 2, 28), yearly.Next(new DateTime(2015, 2, 27)));
            Assert.Equal(new DateTime(2015, 2, 28), yearly.Next(new DateTime(2015, 2, 28)));

            Assert.Null(yearly.Next(new DateTime(2020, 1, 1)));

            Assert.Equal(new DateTime(2015, 1, 31), yearly.Previous(new DateTime(2015, 2, 1)));
            Assert.Equal(new DateTime(2015, 1, 31), yearly.Previous(new DateTime(2015, 2, 28)));
            Assert.Equal(new DateTime(2015, 2, 28), yearly.Previous(new DateTime(2015, 3, 1)));
            Assert.Equal(new DateTime(2015, 2, 28), yearly.Previous(new DateTime(2015, 3, 1)));
            Assert.Equal(new DateTime(2015, 8, 31), yearly.Previous(new DateTime(2015, 9, 1)));

            Assert.Null(yearly.Previous(new DateTime(2015, 1, 31)));
        }

        [Fact]
        public void Yearly_EveryYear_TwoMonthsAfterDateTime()
        {
            // Arrange.
            var startDate = new DateTime(2015, 1, 1);

            IRecurring yearly = Recurs
                .Starting(startDate)
                .Every(1)
                .Years()
                .OnDay(24)
                .OnMonth(startDate.AddMonths(2))
                .Ending(new DateTime(2020, 1, 1))
                .Build();

            // Act.

            // Assert.
            Assert.Equal(new DateTime(2015, 3, 24), yearly.Next(new DateTime(2014, 1, 1)));
            Assert.Equal(new DateTime(2015, 3, 24), yearly.Next(new DateTime(2015, 1, 1)));
            Assert.Equal(new DateTime(2015, 3, 24), yearly.Next(new DateTime(2015, 1, 23)));
            Assert.Equal(new DateTime(2015, 3, 24), yearly.Next(new DateTime(2015, 3, 24)));
            Assert.Equal(new DateTime(2016, 3, 24), yearly.Next(new DateTime(2015, 3, 25)));
            Assert.Equal(new DateTime(2016, 3, 24), yearly.Next(new DateTime(2015, 10, 1)));
            Assert.Equal(new DateTime(2016, 3, 24), yearly.Next(new DateTime(2015, 10, 23)));
            Assert.Equal(new DateTime(2016, 3, 24), yearly.Next(new DateTime(2015, 10, 24)));
            Assert.Equal(new DateTime(2016, 3, 24), yearly.Next(new DateTime(2016, 3, 24)));
            Assert.Equal(new DateTime(2017, 3, 24), yearly.Next(new DateTime(2016, 4, 24)));

            Assert.Null(yearly.Next(new DateTime(2020, 1, 1)));

            Assert.Equal(new DateTime(2015, 3, 24), yearly.Previous(new DateTime(2015, 3, 25)));
            Assert.Equal(new DateTime(2015, 3, 24), yearly.Previous(new DateTime(2015, 10, 25)));
            Assert.Equal(new DateTime(2015, 3, 24), yearly.Previous(new DateTime(2016, 3, 24)));
            Assert.Equal(new DateTime(2016, 3, 24), yearly.Previous(new DateTime(2016, 3, 25)));
            Assert.Equal(new DateTime(2016, 3, 24), yearly.Previous(new DateTime(2017, 3, 24)));
            Assert.Equal(new DateTime(2017, 3, 24), yearly.Previous(new DateTime(2017, 3, 25)));
            Assert.Equal(new DateTime(2017, 3, 24), yearly.Previous(new DateTime(2018, 3, 24)));

            Assert.Null(yearly.Previous(new DateTime(2015, 3, 24)));
        }

        [Fact]
        public void Yearly_EveryYear_Ordinal()
        {
            // Arrange.
            var startDate = new DateTime(2018, 1, 1);

            IRecurring yearly = Recurs
                .Starting(startDate)
                .Every(1)
                .Years()
                .OnOrdinalWeek(Ordinal.THIRD)
                .OnDay(DayOfWeek.Thursday)
                .OnMonths(Month.JANUARY)
                .Ending(new DateTime(2030, 1, 1))
                .Build();

            // Act.

            // Assert.
            Assert.Equal(new DateTime(2018, 1, 18), yearly.Next(new DateTime(2014, 1, 1)));
            Assert.Equal(new DateTime(2018, 1, 18), yearly.Next(new DateTime(2018, 1, 1)));
            Assert.Equal(new DateTime(2018, 1, 18), yearly.Next(new DateTime(2018, 1, 18)));
            Assert.Equal(new DateTime(2020, 1, 16), yearly.Next(new DateTime(2019, 2, 18)));

            Assert.Null(yearly.Next(new DateTime(2030, 1, 1)));

            Assert.Equal(new DateTime(2018, 1, 18), yearly.Previous(new DateTime(2018, 1, 19)));
            Assert.Equal(new DateTime(2018, 1, 18), yearly.Previous(new DateTime(2019, 1, 17)));
            Assert.Equal(new DateTime(2019, 1, 17), yearly.Previous(new DateTime(2019, 1, 18)));
            Assert.Equal(new DateTime(2020, 1, 16), yearly.Previous(new DateTime(2020, 1, 17)));

            Assert.Null(yearly.Previous(new DateTime(2018, 1, 18)));
        }

        [Fact]
        public void Yearly_EveryThirdYear_Ordinal()
        {
            // Arrange.
            var startDate = new DateTime(2018, 1, 1);

            IRecurring yearly = Recurs
                .Starting(startDate)
                .Every(3)
                .Years()
                .OnOrdinalWeek(Ordinal.THIRD)
                .OnDay(DayOfWeek.Thursday)
                .OnMonths(Month.JANUARY)
                .Ending(new DateTime(2030, 1, 1))
                .Build();

            // Act.

            // Assert.
            Assert.Equal(new DateTime(2018, 1, 18), yearly.Next(new DateTime(2014, 1, 1)));
            Assert.Equal(new DateTime(2018, 1, 18), yearly.Next(new DateTime(2014, 1, 1)));
            Assert.Equal(new DateTime(2018, 1, 18), yearly.Next(new DateTime(2018, 1, 1)));
            Assert.Equal(new DateTime(2018, 1, 18), yearly.Next(new DateTime(2018, 1, 18)));
            Assert.Equal(new DateTime(2024, 1, 18), yearly.Next(new DateTime(2021, 2, 18)));

            Assert.Null(yearly.Next(new DateTime(2030, 1, 1)));

            Assert.Equal(new DateTime(2018, 1, 18), yearly.Previous(new DateTime(2018, 1, 19)));
            Assert.Equal(new DateTime(2018, 1, 18), yearly.Previous(new DateTime(2021, 1, 21)));
            Assert.Equal(new DateTime(2021, 1, 21), yearly.Previous(new DateTime(2021, 1, 22)));
            Assert.Equal(new DateTime(2024, 1, 18), yearly.Previous(new DateTime(2024, 1, 19)));

            Assert.Null(yearly.Previous(new DateTime(2018, 1, 18)));
        }

        [Fact]
        public void Yearly_MultipleMonths_Ordinal()
        {
            // Arrange.
            var startDate = new DateTime(2018, 1, 1);

            IRecurring yearly = Recurs
                .Starting(startDate)
                .Every(1)
                .Years()
                .OnOrdinalWeek(Ordinal.THIRD)
                .OnDay(DayOfWeek.Thursday)
                .OnMonths(Month.JANUARY | Month.APRIL)
                .Ending(new DateTime(2030, 1, 1))
                .Build();

            // Act.

            // Assert.
            Assert.Equal(new DateTime(2018, 1, 18), yearly.Next(new DateTime(2014, 1, 1)));
            Assert.Equal(new DateTime(2018, 1, 18), yearly.Next(new DateTime(2018, 1, 1)));
            Assert.Equal(new DateTime(2018, 1, 18), yearly.Next(new DateTime(2018, 1, 18)));
            Assert.Equal(new DateTime(2018, 4,19), yearly.Next(new DateTime(2018, 4, 19)));

            Assert.Null(yearly.Next(new DateTime(2030, 1, 1)));

            Assert.Equal(new DateTime(2018, 1, 18), yearly.Previous(new DateTime(2018, 1, 19)));
            Assert.Equal(new DateTime(2018, 1, 18), yearly.Previous(new DateTime(2018, 4, 19)));
            Assert.Equal(new DateTime(2018, 4, 19), yearly.Previous(new DateTime(2018, 4, 20)));
            Assert.Equal(new DateTime(2019, 1, 17), yearly.Previous(new DateTime(2019, 1, 18)));

            Assert.Null(yearly.Previous(new DateTime(2018, 1, 18)));
        }

        [Fact]
        public void Yearly_EveryYear_Ordinal_Today()
        {
            // Arrange.
            var startDate = new DateTime(2019, 1, 1,12,00,00);

            IRecurring yearly = Recurs
                .Starting(startDate)
                .Every(1)
                .Years()
                .OnOrdinalWeek(Ordinal.FIRST)
                .OnDay(DayOfWeek.Monday)
                .OnMonths(Month.JANUARY)
                .Ending(new DateTime(2030, 1, 1))
                .Build();

            // Act.

            // Assert.
            Assert.Equal(new DateTime(2020,01,6,12,00,00), yearly.Next(new DateTime(2020,01,06,08,00,00)));
            
        }

    }
}

