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
	public class PredictionsController : ControllerBase
	{
		public struct PredictionJoin
		{
			public Match Match;
			public Prediction Prediction;
		}

		public struct MatchPick
		{
			public string MatchId;
			public Pick Pick;
		}

		public struct PutData
		{
			public string PoolerId;
			public MatchPick[] Picks;
		}

		private readonly MatchService _matchService;
		private readonly PredictionService _predictionService;

		public PredictionsController(MatchService matchService, PredictionService predictionService)
		{
			_matchService = matchService;
			_predictionService = predictionService;
		}

		[HttpGet("season/{season}/{type}")]
		public ActionResult<PredictionJoin[]> GetSeasonPredictions(string season, string type)
		{
			int seasonYear = ControllerUtils.ParseSeasonYear(season, out ValidationProblemDetails error);
			if (error != null) return ValidationProblem(error);
			// TODO: Handle season types
			// TODO: Get the pooler id from the logged in user (based on token)

			return FetchPredictions(_matchService.Get(seasonYear), "");
		}

		[HttpGet("season/{season}/{week}/{type}")]
		public ActionResult<PredictionJoin[]> GetSeasonPredictions(string season, string week, string type)
		{
			int seasonYear = ControllerUtils.ParseSeasonYear(season, out ValidationProblemDetails yearError);
			if (yearError != null) return ValidationProblem(yearError);

			int weekNum = ControllerUtils.ParseWeekNum(week, out ValidationProblemDetails weekError);
			if (weekError != null) return ValidationProblem(weekError);
			// TODO: Handle season types
			// TODO: Get the pooler id from the logged in user (based on token)

			Match[] seasonMatches = _matchService.Get(seasonYear, weekNum);
			return FetchPredictions(_matchService.Get(seasonYear, weekNum), "");
		}

		[HttpPut("week")]
		public ActionResult<string> PutWeekPrediction([FromBody] PutData request)
		{
			// TODO: Organise picks and save to DB
			return "";
		}

		private PredictionJoin[] FetchPredictions(Match[] matches, string poolerId)
		{
			// Create structure for matches with prediction joined
			return matches.Select
			(m =>
				new PredictionJoin
				{
					Match = m,
					Prediction = _predictionService.Get(m.Id, "").FirstOrDefault()
				}
			).ToArray();
		}
	}
}