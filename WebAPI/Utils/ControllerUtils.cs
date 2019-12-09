using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Utils
{
	public class ControllerUtils
	{
		public static int ParseSeasonYear(string season, out ValidationProblemDetails error)
		{
			if (!int.TryParse(season, out int seasonYear))
			{
				error = new ValidationProblemDetails();
				error.Status = 400;
				error.Type = "Bad Request";
				error.Title = "Could not parse Season param";
				error.Detail = $"Could not parse {season} as a season year";

				return -1;
			}
			else
			{
				error = null;
				return seasonYear;
			}
		}

		public static int ParseWeekNum(string week, out ValidationProblemDetails error)
		{
			if (!int.TryParse(week, out int weekNum))
			{
				error = new ValidationProblemDetails();
				error.Status = 400;
				error.Type = "Bad Request";
				error.Title = "Could not parse Week param";
				error.Detail = $"Could not parse {week} as a week number";

				return -1;
			}
			else
			{
				error = null;
				return weekNum;
			}
		}
	}
}
