Dates.Recurring
====================

Easily calculate the next time at which a recurring event occurs.
Uses a fluent syntax.

![Build Status](https://github.com/gavynriebau/Dates.Recurring/workflows/.NET%20Core/badge.svg)

# Install

	PM> Install-Package Dates.Recurring

# Calculate the next occurrence of a recurring date.

```csharp
// Daily recurrences
var daily = Recurs
    .Starting(new DateTime(2015, 1, 1))
    .Every(1)
    .Days()
    .Ending(new DateTime(2015, 1, 15))
    .Build();

daily.Next(new DateTime(2014, 7, 3));  // 2015/01/01
daily.Next(new DateTime(2015, 1, 1));  // 2015/01/02
daily.Next(new DateTime(2015, 1, 2));  // 2015/01/03
daily.Next(new DateTime(2015, 1, 15)); // null

// Daily recurrences (only on week days).
var daily = Recurs
    .Starting(new DateTime(2015, 1, 1))
    .Every(1)
    .Days()
    .Including(Day.MONDAY | Day.TUESDAY | Day.WEDNESDAY | Day.THURSDAY | Day.FRIDAY)
    .Build();

daily.Next(new DateTime(2014, 7, 3));   // 2015/01/01
daily.Next(new DateTime(2015, 1, 1));   // 2015/01/02
daily.Next(new DateTime(2015, 1, 2));   // 2015/01/05
daily.Next(new DateTime(2015, 1, 5));   // 2015/01/06

// Weekly recurrences
var weekly = Recurs
    .Starting(new DateTime(2015, 1, 1))
    .Every(1)
    .Weeks()
    .FirstDayOfWeek(DayOfWeek.Monday)
    .OnDays(Day.TUESDAY | Day.FRIDAY)
    .Ending(new DateTime(2015, 2, 19))
    .Build();

weekly.Next(new DateTime(2014, 1, 1));  // 2015/01/02
weekly.Next(new DateTime(2015, 1, 2));  // 2015/01/06
weekly.Next(new DateTime(2014, 1, 6));  // 2015/01/09
weekly.Next(new DateTime(2014, 1, 9));  // 2015/01/13

// Monthly recurrences on a set day of the month
var monthly = Recurs
    .Starting(new DateTime(2015, 1, 1))
    .Every(1)
    .Months()
    .OnDay(24)
    .Ending(new DateTime(2016, 2, 4))
    .Build();

monthly.Next(new DateTime(2014, 4, 8));	// 2015/01/24
monthly.Next(new DateTime(2015, 1, 24)); // 2015/02/24
monthly.Next(new DateTime(2015, 2, 24)); // 2015/03/24
monthly.Next(new DateTime(2015, 2, 10)); // 2015/03/24

// Monthly recurrences on an ordinal week and day of the week
var monthly = Recurs
    .Starting(new DateTime(2018, 1, 1)) // Monday
    .Every(1)
    .Months()
    .OnOrdinalWeek(Ordinal.SECOND)
    .OnDay(DayOfWeek.Friday)
    .Ending(new DateTime(2018, 12, 25))
    .Build();

monthly.Next(new DateTime(2017, 1, 1)); // 2018/01/12
monthly.Next(new DateTime(2018, 1, 1)); // 2018/01/12
monthly.Next(new DateTime(2018, 2, 1)); // 2018/02/09
monthly.Next(new DateTime(2018, 9, 1)); // 2018/09/14
monthly.Next(new DateTime(2020, 2, 1)); // null

// Yearly recurrences on particular days of the month
var yearly = Recurs
    .Starting(new DateTime(2015, 1, 1))
    .Every(1)
    .Years()
    .OnDay(24)
    .OnMonths(Month.JANUARY | Month.FEBRUARY | Month.AUGUST)
    .Ending(new DateTime(2020, 1, 1))
    .Build();

yearly.Next(new DateTime(2014, 1, 1));	// 2015/01/24
yearly.Next(new DateTime(2015, 1, 1)); 	// 2015/01/24
yearly.Next(new DateTime(2015, 1, 23)); // 2015/01/24
yearly.Next(new DateTime(2014, 1, 24)); // 2015/02/24
yearly.Next(new DateTime(2014, 2, 24)); // 2015/08/24

// Yearly recurrences on ordinal week, day of week and in January
var yearly = Recurs
    .Starting(new DateTime(2018, 1, 1))
    .Every(1)
    .Years()
    .OnOrdinalWeek(Ordinal.THIRD)
    .OnDay(DayOfWeek.Thursday)
    .OnMonths(Month.JANUARY)
    .Ending(new DateTime(2030, 1, 1))
    .Build();

yearly.Next(new DateTime(2014, 1, 1));  // 2018/01/18
yearly.Next(new DateTime(2018, 1, 1));  // 2018/01/18
yearly.Next(new DateTime(2018, 1, 18)); // 2019/01/17
yearly.Next(new DateTime(2019, 2, 18)); // 2020/01/16
yearly.Next(new DateTime(2030, 1, 1));  // null
```