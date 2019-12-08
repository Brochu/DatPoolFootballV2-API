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
	public class TeamsController : ControllerBase
	{
		private readonly TeamService _service;

		public TeamsController(TeamService service)
		{
			_service = service;
		}

		[HttpGet]
		public ActionResult<List<Team>> Get()
		{
			var teams = _service.Get();
			return teams;
		}

		[HttpGet("{id}")]
		public ActionResult<Team> Get(string id)
		{
			var t = _service.Get(id);
			if (t == null)
			{
				return NotFound();
			}

			return t;
		}

		//[HttpPost]
		//public ActionResult<Team> Create(Team toAdd)
		//{
		//	_service.Create(toAdd);

		//	return CreatedAtRoute("GetBook", new { shortName = toAdd.ShortName }, toAdd);
		//}

		//[HttpPut("{id:length(24)}")]
		//public IActionResult Update(string shortName, Team newTeam)
		//{
		//	var t = _service.Get(shortName);
		//	if (t == null)
		//	{
		//		return NotFound();
		//	}

		//	_service.Update(shortName, newTeam);
		//	return NoContent();
		//}

		//[HttpDelete("{id:length(24)}")]
		//public IActionResult Delete(string shortName)
		//{
		//	var t = _service.Get(shortName);
		//	if (t == null)
		//	{
		//		return NotFound();
		//	}

		//	_service.Remove(t.ShortName);
		//	return NoContent();
		//}
	}
}