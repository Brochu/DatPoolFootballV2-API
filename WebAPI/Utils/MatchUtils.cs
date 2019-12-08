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

			XmlNode weekNode = doc.SelectSingleNode("/ss/gms");

			Match[] matches = new Match[weekNode.ChildNodes.Count];
			for(int i = 0; i < weekNode.ChildNodes.Count; i++)
			{
				XmlNode game = weekNode.ChildNodes[i];
				string id = $"{game.Attributes["eid"].Value}_{game.Attributes["gsis"].Value}";

				var attrLookup = game.Attributes.Cast<XmlAttribute>().ToDictionary(a => a.Name, a => a.Value);
				matches[i] = new Match()
				{
					Id = id,
					Season = int.Parse(weekNode.Attributes["y"].Value),
					Week = int.Parse(weekNode.Attributes["w"].Value),
					Day = DateTimeUtils.ParseDayOfWeek(attrLookup["d"]),
					Time = attrLookup["t"],
					IsFinal = attrLookup["q"].Contains("F", StringComparison.InvariantCultureIgnoreCase),
					HomeCode = attrLookup["h"],
					HomeName = attrLookup["hnn"],
					HomeScore = string.IsNullOrEmpty(attrLookup["hs"]) ? 0 : int.Parse(attrLookup["hs"]),
					VisitCode = attrLookup["v"],
					VisitName = attrLookup["vnn"],
					VisitScore = string.IsNullOrEmpty(attrLookup["vs"]) ? 0 : int.Parse(attrLookup["vs"])
				};
			}

			return matches;
		}
	}
}
