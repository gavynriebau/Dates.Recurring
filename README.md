Dates.Recurring
====================

Easily calculate the next recurrence for recurring dates using a fluent syntax

[![Build status](https://ci.appveyor.com/api/projects/status/rol28n0b18wanuyc?svg=true)](https://ci.appveyor.com/project/gavynriebau/dates-recurring)

# Install

	PM> Install-Package Dates.Recurring

# Calculate the next occurrence of a recurring date.

```csharp
// Weekly recurrences
var weekly = Recurs
    .Starting(new DateTime(2015, 1, 1))
    .Every(1)
    .Weeks()
    .On(Day.TUESDAY | Day.FRIDAY)
    .Ending(new DateTime(2015, 2, 19))
    .Build();

var nextWeekly = weekly.Next(new DateTime(2014, 1, 1); // 2015/01/02

// Monthly recurrences
var monthly = Recurs
    .Starting(new DateTime(2015, 1, 1))
    .Every(1)
    .Months()
    .OnDay(24)
    .Ending(new DateTime(2016, 2, 4))
    .Build();

var nextMonthly = monthly.Next(new DateTime(2014, 4, 8); // 2015/01/24
```
