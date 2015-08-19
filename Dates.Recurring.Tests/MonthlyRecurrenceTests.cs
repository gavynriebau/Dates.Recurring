using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dates.Recurring.Tests
{
    [TestFixture]
    public class MonthlyRecurrenceTests
    {

        [Test]
        public void Monthly_EveryMonth()
        {
            // Arrange.
            var monthly = Recurs
                .Starting(new DateTime(2015, 1, 1))
                .Every(1)
                .Months()
                .OnDay(24)
                .Ending(new DateTime(2016, 2, 4))
                .Build();

            // Act.

            // Assert.
            Assert.That(monthly.Next(new DateTime(2014, 4, 8)), Is.EqualTo(new DateTime(2015, 1, 24)));
            Assert.That(monthly.Next(new DateTime(2015, 1, 24)), Is.EqualTo(new DateTime(2015, 2, 24)));
            Assert.That(monthly.Next(new DateTime(2015, 2, 23)), Is.EqualTo(new DateTime(2015, 2, 24)));
            Assert.That(monthly.Next(new DateTime(2015, 2, 24)), Is.EqualTo(new DateTime(2015, 3, 24)));
            Assert.That(monthly.Next(new DateTime(2015, 2, 25)), Is.EqualTo(new DateTime(2015, 3, 24)));
            Assert.That(monthly.Next(new DateTime(2015, 6, 3)), Is.EqualTo(new DateTime(2015, 6, 24)));
            Assert.That(monthly.Next(new DateTime(2016, 6, 3)), Is.Null);
        }

        [Test]
        public void Monthly_EveryThirdMonth()
        {
            // Arrange.
            var monthly = Recurs
                .Starting(new DateTime(2015, 1, 1))
                .Every(3)
                .Months()
                .OnDay(24)
                .Ending(new DateTime(2016, 2, 4))
                .Build();

            // Act.

            // Assert.
            Assert.That(monthly.Next(new DateTime(2014, 2, 1)), Is.EqualTo(new DateTime(2015, 1, 24)));
            Assert.That(monthly.Next(new DateTime(2015, 1, 24)), Is.EqualTo(new DateTime(2015, 4, 24)));
            Assert.That(monthly.Next(new DateTime(2015, 1, 25)), Is.EqualTo(new DateTime(2015, 4, 24)));
            Assert.That(monthly.Next(new DateTime(2015, 2, 1)), Is.EqualTo(new DateTime(2015, 4, 24)));
            Assert.That(monthly.Next(new DateTime(2015, 2, 17)), Is.EqualTo(new DateTime(2015, 4, 24)));
            Assert.That(monthly.Next(new DateTime(2015, 4, 23)), Is.EqualTo(new DateTime(2015, 4, 24)));
            Assert.That(monthly.Next(new DateTime(2015, 4, 24)), Is.EqualTo(new DateTime(2015, 7, 24)));
            Assert.That(monthly.Next(new DateTime(2016, 6, 3)), Is.Null);
        }

        [Test]
        public void Monthly_EveryMonth_DifferentDaysInMonths()
        {
            // Arrange.
            var monthly = Recurs
                .Starting(new DateTime(2015, 1, 1))
                .Every(1)
                .Months()
                .OnDay(31)
                .Ending(new DateTime(2016, 2, 4))
                .Build();

            // Act.

            // Assert.
            Assert.That(monthly.Next(new DateTime(2014, 2, 1)), Is.EqualTo(new DateTime(2015, 1, 31)));
            Assert.That(monthly.Next(new DateTime(2015, 1, 30)), Is.EqualTo(new DateTime(2015, 1, 31)));
            Assert.That(monthly.Next(new DateTime(2015, 1, 31)), Is.EqualTo(new DateTime(2015, 2, 28)));
            Assert.That(monthly.Next(new DateTime(2015, 2, 27)), Is.EqualTo(new DateTime(2015, 2, 28)));
            Assert.That(monthly.Next(new DateTime(2015, 2, 28)), Is.EqualTo(new DateTime(2015, 3, 31)));
            Assert.That(monthly.Next(new DateTime(2015, 3, 31)), Is.EqualTo(new DateTime(2015, 4, 30)));
            Assert.That(monthly.Next(new DateTime(2016, 6, 3)), Is.Null);
        }

    }
}

