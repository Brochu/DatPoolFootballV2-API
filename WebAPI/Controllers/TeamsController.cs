using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using WebAPI.Models;
using WebAPI.Services;

namespace WebAPI.Controllers
{
	public class TeamsController : Controller
	{
		private readonly TeamService _service;

		public TeamsController(TeamService teamService)
		{
			_service = teamService;
		}

		[HttpGet]
		public ActionResult<List<Team>> Get() =>
			_service.Get();

		[HttpGet("{id:length(24)}", Name = "GetTeam")]
		public ActionResult<Team> Get(string shortName)
		{
			var t = _service.Get(shortName);
			if (t == null)
			{
				return NotFound();
			}

			return t;
		}

		[HttpPost]
		public ActionResult<Team> Create(Team toAdd)
		{
			_service.Create(toAdd);

			return CreatedAtRoute("GetBook", new { shortName = toAdd.ShortName }, toAdd);
		}

		[HttpPut("{id:length(24)}")]
		public IActionResult Update(string shortName, Team newTeam)
		{
			var t = _service.Get(shortName);
			if (t == null)
			{
				return NotFound();
			}

			_service.Update(shortName, newTeam);
			return NoContent();
		}

		[HttpDelete("{id:length(24)}")]
		public IActionResult Delete(string shortName)
		{
			var t = _service.Get(shortName);
			if (t == null)
			{
				return NotFound();
			}

			_service.Remove(t.ShortName);
			return NoContent();
		}
	}
}