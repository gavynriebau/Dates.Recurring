using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dates.Recurring.Tests
{
    [TestFixture]
    public class DailyRecurrenceTests
    {
        [Test]
        public void Daily_EveryDay()
        {
            // Arrange.
            var daily = Recurs
                .Starting(new DateTime(2015, 1, 1))
                .Every(1)
                .Days()
                .Ending(new DateTime(2015, 1, 15))
                .Build();

            // Act.

            // Assert.
            Assert.That(daily.Next(new DateTime(2014, 7, 3)), Is.EqualTo(new DateTime(2015, 1, 1)));
            Assert.That(daily.Next(new DateTime(2015, 1, 1)), Is.EqualTo(new DateTime(2015, 1, 2)));
            Assert.That(daily.Next(new DateTime(2015, 1, 2)), Is.EqualTo(new DateTime(2015, 1, 3)));
            Assert.That(daily.Next(new DateTime(2015, 1, 15)), Is.Null);
        }

        [Test]
        public void Daily_EveryThirdDay()
        {
            // Arrange.
            var daily = Recurs
                .Starting(new DateTime(2015, 1, 1))
                .Every(3)
                .Days()
                .Build();

            // Act.

            // Assert.
            Assert.That(daily.Next(new DateTime(2014, 7, 3)), Is.EqualTo(new DateTime(2015, 1, 1)));
            Assert.That(daily.Next(new DateTime(2015, 1, 1)), Is.EqualTo(new DateTime(2015, 1, 4)));
            Assert.That(daily.Next(new DateTime(2015, 1, 5)), Is.EqualTo(new DateTime(2015, 1, 7)));
        }

    }
}
