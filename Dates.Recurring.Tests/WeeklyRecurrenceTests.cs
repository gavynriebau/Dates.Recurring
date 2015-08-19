using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dates.Recurring.Tests
{
    [TestFixture]
    public class WeeklyRecurrenceTests
    {
        [Test]
        public void Weekly_EveryWeek()
        {
            // Arrange.
            var weekly = Recurs
                .Starting(new DateTime(2015, 1, 1))
                .Every(1)
                .Weeks()
                .On(Day.TUESDAY | Day.FRIDAY)
                .Ending(new DateTime(2015, 2, 19))
                .Build();

            // Act.

            // Assert.
            Assert.That(weekly.Next(new DateTime(2014, 1, 1)), Is.EqualTo(new DateTime(2015, 1, 2)));
            Assert.That(weekly.Next(new DateTime(2015, 1, 2)), Is.EqualTo(new DateTime(2015, 1, 6)));
            Assert.That(weekly.Next(new DateTime(2015, 1, 6)), Is.EqualTo(new DateTime(2015, 1, 9)));
            Assert.That(weekly.Next(new DateTime(2015, 1, 9)), Is.EqualTo(new DateTime(2015, 1, 13)));
            Assert.That(weekly.Next(new DateTime(2015, 1, 13)), Is.EqualTo(new DateTime(2015, 1, 16)));
        }

        [Test]
        public void Weekly_EveryThirdWeek()
        {
            // Arrange.
            var weekly = Recurs
                .Starting(new DateTime(2015, 1, 1))
                .Every(3)
                .Weeks()
                .On(Day.TUESDAY | Day.FRIDAY)
                .Ending(new DateTime(2015, 2, 19))
                .Build();

            // Act.

            // Assert.
            Assert.That(weekly.Next(new DateTime(2014, 1, 1)), Is.EqualTo(new DateTime(2015, 1, 2)));
            Assert.That(weekly.Next(new DateTime(2015, 1, 2)), Is.EqualTo(new DateTime(2015, 1, 20)));
            Assert.That(weekly.Next(new DateTime(2015, 1, 21)), Is.EqualTo(new DateTime(2015, 1, 23)));
            Assert.That(weekly.Next(new DateTime(2015, 1, 23)), Is.EqualTo(new DateTime(2015, 2, 10)));
            Assert.That(weekly.Next(new DateTime(2015, 1, 24)), Is.EqualTo(new DateTime(2015, 2, 10)));
            Assert.That(weekly.Next(new DateTime(2015, 1, 27)), Is.EqualTo(new DateTime(2015, 2, 10)));
            Assert.That(weekly.Next(new DateTime(2015, 2, 10)), Is.EqualTo(new DateTime(2015, 2, 13)));
        }
    }
}
