Dates.Recurring
====================

Easily calculate the next time at which a recurring event occurs.
Uses a fluent syntax.

[![Build status](https://ci.appveyor.com/api/projects/status/rol28n0b18wanuyc?svg=true)](https://ci.appveyor.com/project/gavynriebau/dates-recurring)

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

// Weekly recurrences
var weekly = Recurs
    .Starting(new DateTime(2015, 1, 1))
    .Every(1)
    .Weeks()
    .On(Day.TUESDAY | Day.FRIDAY)
    .Ending(new DateTime(2015, 2, 19))
    .Build();

weekly.Next(new DateTime(2014, 1, 1);  // 2015/01/02
weekly.Next(new DateTime(2015, 1, 2);  // 2015/01/06
weekly.Next(new DateTime(2014, 1, 6);  // 2015/01/09
weekly.Next(new DateTime(2014, 1, 9);  // 2015/01/13

// Monthly recurrences
var monthly = Recurs
    .Starting(new DateTime(2015, 1, 1))
    .Every(1)
    .Months()
    .OnDay(24)
    .Ending(new DateTime(2016, 2, 4))
    .Build();

monthly.Next(new DateTime(2014, 4, 8);	// 2015/01/24
monthly.Next(new DateTime(2015, 1, 24); // 2015/02/24
monthly.Next(new DateTime(2015, 2, 24); // 2015/03/24
monthly.Next(new DateTime(2015, 2, 10); // 2015/03/24

// Yearly recurrences
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
```
