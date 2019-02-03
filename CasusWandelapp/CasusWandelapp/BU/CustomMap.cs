using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms.Maps;
using static CasusWandelapp.BU.Route;


namespace CasusWandelapp.BU
{
    public class CustomMap : Map
    {
		public List<Position> RouteCoordinates { get; set; }

        //public List<CustomPin> CustomPins { get; set; }

        public List<RouteStartPoint> RouteStartPoints { get; set; }

        public CustomMap ()
		{
			RouteCoordinates = new List<Position> ();
		}
    }
}
