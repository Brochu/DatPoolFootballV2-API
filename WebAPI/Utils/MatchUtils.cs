using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;

using WebAPI.Models;

namespace WebAPI.Utils
{
	public static class MatchUtils
	{
		public static Match[] ParseWeekFromXml(string xml)
		{
			XmlDocument doc = new XmlDocument();
			doc.LoadXml(xml);

			XmlNode weekNode = doc.SelectSingleNode("/gms");
			XmlNodeList games = doc.SelectNodes("//g");

			Match[] matches = new Match[games.Count];
			for(int i = 0; i < games.Count; i++)
			{
				XmlNode game = games[i];
				string id = $"{game.Attributes["eid"].Value}_{game.Attributes["gsis"].Value}";

				matches[i] = new Match()
				{
					Id = id,
					Season = int.Parse(weekNode.Attributes["y"].Value),
					Week = int.Parse(weekNode.Attributes["w"].Value),
					Day = DateTimeUtils.ParseDayOfWeek(game.Attributes["d"].Value),
					Time = game.Attributes["t"].Value,
					IsFinal = game.Attributes["q"].Value.Equals("F", StringComparison.InvariantCultureIgnoreCase),
					HomeCode = game.Attributes["h"].Value,
					HomeName = game.Attributes["hnn"].Value,
					HomeScore = int.Parse(game.Attributes["hs"].Value),
					VisitCode = game.Attributes["v"].Value,
					VisitName = game.Attributes["vnn"].Value,
					VisitScore = int.Parse(game.Attributes["vs"].Value),
				};
			}

			return matches;
		}
	}
}
