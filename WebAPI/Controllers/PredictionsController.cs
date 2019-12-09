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

			Match[] seasonMatches = _matchService.Get(seasonYear);
			// Create structure for matches with prediction joined

			return new PredictionJoin[0];
		}

		[HttpPut("week")]
		public ActionResult<string> PutWeekPrediction([FromBody] PutData request)
		{
			// TODO: Organise picks and save to DB
			return "";
		}
	}
}