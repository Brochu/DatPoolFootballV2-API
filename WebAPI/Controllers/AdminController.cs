using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
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
		public async Task<ActionResult<string>> PutUpdateMatches(string season, string week, string type)
		{
			string url = string.Format(_settings.UpdateUrl, season, week, type);
			var request = (HttpWebRequest)WebRequest.Create(url);
			WebResponse response = await request.GetResponseAsync();

			using(StreamReader sr = new StreamReader(response.GetResponseStream()))
			{
				string xml = await sr.ReadToEndAsync();

				return xml;
			}
			// Create match model
			// Parse XML to matches
			// Save matches in DB
		}
	}
}