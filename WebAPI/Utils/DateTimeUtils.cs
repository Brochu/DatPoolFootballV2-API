using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Utils
{
	public static class DateTimeUtils
	{
		public static DayOfWeek ParseDayOfWeek(string dayOfWeekStr)
		{
			if      (dayOfWeekStr.Equals("Sun", StringComparison.InvariantCultureIgnoreCase)) return (DayOfWeek)0;
			else if (dayOfWeekStr.Equals("Mon", StringComparison.InvariantCultureIgnoreCase)) return (DayOfWeek)1;
			else if (dayOfWeekStr.Equals("Tue", StringComparison.InvariantCultureIgnoreCase)) return (DayOfWeek)2;
			else if (dayOfWeekStr.Equals("Wed", StringComparison.InvariantCultureIgnoreCase)) return (DayOfWeek)3;
			else if (dayOfWeekStr.Equals("Thu", StringComparison.InvariantCultureIgnoreCase)) return (DayOfWeek)4;
			else if (dayOfWeekStr.Equals("Fri", StringComparison.InvariantCultureIgnoreCase)) return (DayOfWeek)5;
			else if (dayOfWeekStr.Equals("Sat", StringComparison.InvariantCultureIgnoreCase)) return (DayOfWeek)6;

			else return 0;
		}
	}
}
