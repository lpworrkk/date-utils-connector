//-- tested at: https://dotnetfiddle.net/
using System;

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
		
		//-- the following is for fake testing of the isLastDayOfTheMonth();
		DateTime firstDayOfNextMonth = new DateTime( DateTime.Now.Year, DateTime.Now.AddMonths(1).Month, 1 );
		Console.WriteLine("firstDayOfNextMonth.AddSeconds(-1): " + firstDayOfNextMonth.AddSeconds(-1));
		Console.WriteLine("Pass firstDayOfNextMonth(-1) to the isLastDayOfTheMonth() == " + isLastDayOfTheMonth(firstDayOfNextMonth.AddSeconds(-1)));
		
		//-- testing parsing date from string
		string dateTest = "07/01/2025";
		var parsedDate = DateTime.Parse(dateTest);
		Console.WriteLine("parsedDate: " + parsedDate);

        Console.ReadLine(); // Keep the console window open
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
}
