using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using WebAPI.Models;
using WebAPI.Services;
using WebAPI.Utils;

namespace WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AdminController : ControllerBase
	{
		private INflDataSettings _settings;
		private readonly MatchService _service;

		public AdminController(INflDataSettings settings, MatchService service)
		{
			_settings = settings;
			_service = service;
		}

		[HttpPut("UpdateMatches/{season}/{week}/{type}")]
		public async Task<ActionResult<Match[]>> PutUpdateMatches(string season, string week, string type)
		{
			string url = string.Format(_settings.UpdateUrl, season, week, type);
			var request = (HttpWebRequest)WebRequest.Create(url);
			WebResponse response = await request.GetResponseAsync();

			using(StreamReader sr = new StreamReader(response.GetResponseStream()))
			{
				string xml = await sr.ReadToEndAsync();
				Match[] matches = MatchUtils.ParseWeekFromXml(xml);

				_service.BatchWeek(matches);
				return matches;
			}
		}

		[HttpPut("UpdateMatchesManual/{season}/{week}/{type}")]
		public ActionResult<Match[]> PutUpdateMatchesManual([FromBody] Match[] matches)
		{
			_service.BatchWeek(matches);
			return matches;
		}
	}
}