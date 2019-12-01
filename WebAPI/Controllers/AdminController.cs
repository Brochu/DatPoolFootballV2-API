using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using WebAPI.Models;
using WebAPI.Services;

namespace WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AdminController : ControllerBase
	{
		private INflDataSettings _settings;

		public AdminController(INflDataSettings settings)
		{
			_settings = settings;
		}

		[HttpPut("UpdateMatches/{season}/{week}/{type}")]
		public ActionResult<string> PutUpdateMatches(string season, string week, string type)
		{
			string url = string.Format(_settings.UpdateUrl, season, week, type);
			return $"GOT IT: url to call = {url}";
		}
	}
}