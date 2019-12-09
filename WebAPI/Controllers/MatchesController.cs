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
			int seasonYear = ControllerUtils.ParseSeasonYear(season, out ValidationProblemDetails error);
			if (error != null) return ValidationProblem(error);
			// TODO: Handle season types

			return _service.Get(seasonYear);
		}

		[HttpGet("week/{season}/{week}/{type}")]
		public ActionResult<Match[]> GetWeekMatches(string season, string week, string type)
		{
			int seasonYear = ControllerUtils.ParseSeasonYear(season, out ValidationProblemDetails seasonError);
			if (seasonError != null) return ValidationProblem(seasonError);

			int weekNum = ControllerUtils.ParseWeekNum(week, out ValidationProblemDetails weekError);
			if (weekError != null) return ValidationProblem(weekError);
			// TODO: Handle season type

			return _service.Get(seasonYear, weekNum);
		}
	}
}