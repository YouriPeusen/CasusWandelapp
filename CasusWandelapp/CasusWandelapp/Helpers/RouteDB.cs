using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace CasusWandelapp.Helpers
{
    public class RouteDB
	{
		[PrimaryKey, AutoIncrement]
		public int RouteId { get; set; }

		[MaxLength(250)]
		public string RouteName { get; set; }
		public string RouteLenght { get; set; }
		public string RouteDifficulty { get; set; }
	}
}
