using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using WebAPI.Models;
using WebAPI.Services;
using WebAPI.Utils;

namespace WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class MatchesController : ControllerBase
	{
		private readonly MatchService _service;

		public MatchesController(MatchService service)
		{
			_service = service;
		}

		[HttpGet("season/{season}/{type}")]
		public ActionResult<Match[]> GetSeasonMatches(string season, string type)
		{
			if (!int.TryParse(season, out int seasonYear))
			{
				return ValidationProblem(ErrorUtils.CreateErrorDetails(
					400,
					"Could not parse Season param",
					$"Could not parse {season} as a season year",
					"Bad Request")
				);
			}
			// TODO: Handle season types

			return _service.Get(seasonYear);
		}

		[HttpGet("week/{season}/{week}/{type}")]
		public ActionResult<Match[]> GetWeekMatches(string season, string week, string type)
		{
			if (!int.TryParse(season, out int seasonYear))
			{
				return ValidationProblem(ErrorUtils.CreateErrorDetails(
					400,
					"Could not parse Season param",
					$"Could not parse {season} as a season year",
					"Bad Request")
				);
			}
			if (!int.TryParse(week, out int weekNum))
			{
				return ValidationProblem(ErrorUtils.CreateErrorDetails(
					400,
					"Could not parse Week param",
					$"Could not parse {week} as a week number",
					"Bad Request")
				);
			}
			// TODO: Handle season type

			return _service.Get(seasonYear, weekNum);
		}
	}
}