//-- tested at: https://dotnetfiddle.net/
using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        int month = 9; // Example month (September)
        int year = 2023; // Example year

        DateTime firstDayOfMonth;
        DateTime lastDayOfMonth;

        GetMonthBoundaries(month, year, out firstDayOfMonth, out lastDayOfMonth);

        Console.WriteLine("First day of the month: " + firstDayOfMonth.ToLongDateString());
        Console.WriteLine("Last day of the month: " + lastDayOfMonth.ToLongDateString());
		Console.WriteLine("Today's Day: " + DateTime.Now.Day);
		
		Console.WriteLine("Is today the last day of the month: " + isLastDayOfTheMonth(DateTime.Now));
		
		//-- test getting last 7 days
		// Get the start and end date range of last 7 days.
        var resultLast7DaysRange = GetLast7DaysDateRange(DateTime.Today);
        foreach (DateTime date in resultLast7DaysRange)
        {
            Console.WriteLine(date);
        }		
		
		//-- the following is for fake testing of the isLastDayOfTheMonth();
		DateTime firstDayOfNextMonth = new DateTime( DateTime.Now.Year, DateTime.Now.AddMonths(1).Month, 1 );
		Console.WriteLine("firstDayOfNextMonth.AddSeconds(-1): " + firstDayOfNextMonth.AddSeconds(-1));
		Console.WriteLine("Pass firstDayOfNextMonth(-1) to the isLastDayOfTheMonth() == " + isLastDayOfTheMonth(firstDayOfNextMonth.AddSeconds(-1)));
		
		//-- testing parsing date from string
		string dateTest = "07/01/2025";
		var parsedDate = DateTime.Parse(dateTest);
		Console.WriteLine("parsedDate: " + parsedDate);

		Console.WriteLine("Testing: " + (DateTime.Now.AddDays(1)).Day);
    }

    static void GetMonthBoundaries(int month, int year, out DateTime firstDayOfMonth, out DateTime lastDayOfMonth)
    {
        // Get the 1st day of the month (always day 1)
        DateTime first = new DateTime(year, month, 1);

        // Calculate the last day of the month
        DateTime last = first.AddMonths(1).AddSeconds(-1);

        // Set the out parameters
        firstDayOfMonth = first;
        lastDayOfMonth = last;
    }
	
	static bool isLastDayOfTheMonth(DateTime dateIn) 
	{
		DateTime tomorrow = dateIn.AddDays(1);
		if ( tomorrow.Day==1 ) {
			return true;
		}
		return false;
	}
	
	// Returns a list with two dates: 7 days ago and today
    public static List<DateTime> GetLast7DaysDateRange(DateTime today)
    {
        List<DateTime> result = new List<DateTime> {
            today.AddDays(-7), // 7 days ago from today
            today              // today
        };
        
        return result;
    }
}
