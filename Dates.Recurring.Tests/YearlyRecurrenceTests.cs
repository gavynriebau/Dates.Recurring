using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dates.Recurring.Tests
{
    [TestFixture]
    public class YearlyRecurrenceTests
    {

        [Test]
        public void Yearly_EveryYear()
        {
            // Arrange.
            var yearly = Recurs
                .Starting(new DateTime(2015, 1, 1))
                .Every(1)
                .Years()
                .OnDay(24)
                .OnMonths(Month.JANUARY | Month.FEBRUARY | Month.AUGUST)
                .Ending(new DateTime(2020, 1, 1))
                .Build();

            // Act.

            // Assert.
            Assert.That(yearly.Next(new DateTime(2014, 1, 1)), Is.EqualTo(new DateTime(2015, 1, 24)));
            Assert.That(yearly.Next(new DateTime(2015, 1, 1)), Is.EqualTo(new DateTime(2015, 1, 24)));
            Assert.That(yearly.Next(new DateTime(2015, 1, 23)), Is.EqualTo(new DateTime(2015, 1, 24)));
            Assert.That(yearly.Next(new DateTime(2015, 1, 24)), Is.EqualTo(new DateTime(2015, 2, 24)));
            Assert.That(yearly.Next(new DateTime(2015, 1, 25)), Is.EqualTo(new DateTime(2015, 2, 24)));
            Assert.That(yearly.Next(new DateTime(2015, 2, 1)), Is.EqualTo(new DateTime(2015, 2, 24)));
            Assert.That(yearly.Next(new DateTime(2015, 2, 23)), Is.EqualTo(new DateTime(2015, 2, 24)));
            Assert.That(yearly.Next(new DateTime(2015, 2, 24)), Is.EqualTo(new DateTime(2015, 8, 24)));
            Assert.That(yearly.Next(new DateTime(2015, 3, 24)), Is.EqualTo(new DateTime(2015, 8, 24)));
            Assert.That(yearly.Next(new DateTime(2015, 4, 24)), Is.EqualTo(new DateTime(2015, 8, 24)));
            Assert.That(yearly.Next(new DateTime(2015, 5, 24)), Is.EqualTo(new DateTime(2015, 8, 24)));
            Assert.That(yearly.Next(new DateTime(2015, 6, 24)), Is.EqualTo(new DateTime(2015, 8, 24)));
            Assert.That(yearly.Next(new DateTime(2015, 7, 24)), Is.EqualTo(new DateTime(2015, 8, 24)));
            Assert.That(yearly.Next(new DateTime(2015, 8, 24)), Is.EqualTo(new DateTime(2016, 1, 24)));
            Assert.That(yearly.Next(new DateTime(2016, 1, 24)), Is.EqualTo(new DateTime(2016, 2, 24)));
            Assert.That(yearly.Next(new DateTime(2020, 1, 1)), Is.Null);
        }

        [Test]
        public void Yearly_EveryThirdYear()
        {
            // Arrange.
            var yearly = Recurs
                .Starting(new DateTime(2015, 1, 1))
                .Every(3)
                .Years()
                .OnDay(24)
                .OnMonths(Month.JANUARY | Month.FEBRUARY | Month.AUGUST)
                .Ending(new DateTime(2020, 1, 1))
                .Build();

            // Act.

            // Assert.
            Assert.That(yearly.Next(new DateTime(2014, 1, 1)), Is.EqualTo(new DateTime(2015, 1, 24)));
            Assert.That(yearly.Next(new DateTime(2015, 1, 1)), Is.EqualTo(new DateTime(2015, 1, 24)));
            Assert.That(yearly.Next(new DateTime(2015, 1, 23)), Is.EqualTo(new DateTime(2015, 1, 24)));
            Assert.That(yearly.Next(new DateTime(2015, 1, 24)), Is.EqualTo(new DateTime(2015, 2, 24)));
            Assert.That(yearly.Next(new DateTime(2015, 1, 25)), Is.EqualTo(new DateTime(2015, 2, 24)));
            Assert.That(yearly.Next(new DateTime(2015, 2, 1)), Is.EqualTo(new DateTime(2015, 2, 24)));
            Assert.That(yearly.Next(new DateTime(2015, 2, 23)), Is.EqualTo(new DateTime(2015, 2, 24)));
            Assert.That(yearly.Next(new DateTime(2015, 2, 24)), Is.EqualTo(new DateTime(2015, 8, 24)));
            Assert.That(yearly.Next(new DateTime(2015, 3, 24)), Is.EqualTo(new DateTime(2015, 8, 24)));
            Assert.That(yearly.Next(new DateTime(2015, 4, 24)), Is.EqualTo(new DateTime(2015, 8, 24)));
            Assert.That(yearly.Next(new DateTime(2015, 5, 24)), Is.EqualTo(new DateTime(2015, 8, 24)));
            Assert.That(yearly.Next(new DateTime(2015, 6, 24)), Is.EqualTo(new DateTime(2015, 8, 24)));
            Assert.That(yearly.Next(new DateTime(2015, 7, 24)), Is.EqualTo(new DateTime(2015, 8, 24)));
            Assert.That(yearly.Next(new DateTime(2015, 8, 24)), Is.EqualTo(new DateTime(2018, 1, 24)));
            Assert.That(yearly.Next(new DateTime(2018, 1, 24)), Is.EqualTo(new DateTime(2018, 2, 24)));
            Assert.That(yearly.Next(new DateTime(2018, 2, 24)), Is.EqualTo(new DateTime(2018, 8, 24)));
            Assert.That(yearly.Next(new DateTime(2018, 6, 11)), Is.EqualTo(new DateTime(2018, 8, 24)));
            Assert.That(yearly.Next(new DateTime(2020, 1, 1)), Is.Null);
        }

        [Test]
        public void Yearly_EveryYear_DifferentDaysInMonth()
        {
            // Arrange.
            var yearly = Recurs
                .Starting(new DateTime(2015, 1, 1))
                .Every(1)
                .Years()
                .OnDay(31)
                .OnMonths(Month.JANUARY | Month.FEBRUARY | Month.AUGUST)
                .Ending(new DateTime(2020, 1, 1))
                .Build();

            // Act.

            // Assert.
            Assert.That(yearly.Next(new DateTime(2014, 1, 1)), Is.EqualTo(new DateTime(2015, 1, 31)));
            Assert.That(yearly.Next(new DateTime(2015, 1, 6)), Is.EqualTo(new DateTime(2015, 1, 31)));
            Assert.That(yearly.Next(new DateTime(2015, 1, 31)), Is.EqualTo(new DateTime(2015, 2, 28)));
            Assert.That(yearly.Next(new DateTime(2015, 2, 27)), Is.EqualTo(new DateTime(2015, 2, 28)));
            Assert.That(yearly.Next(new DateTime(2015, 2, 28)), Is.EqualTo(new DateTime(2015, 8, 31)));
            Assert.That(yearly.Next(new DateTime(2020, 1, 1)), Is.Null);
        }

    }
}

