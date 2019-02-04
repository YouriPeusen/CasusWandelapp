using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms.Maps;
using static CasusWandelapp.BU.Route;
using static CasusWandelapp.BU.POI;

namespace CasusWandelapp.BU
{
    public class CustomMap : Map
    {
        //Hier worden de Route Coordinaten in een lijst opgeslagen
        public List<Position> RouteCoordinates { get; set; }
       
        //Hier worden de Route startpunt Coordinaten in een lijst opgeslagen
        public List<RouteStartPoint> RouteStartPoints { get; set; }
       
        //Hier worden de POI Coordinaten in een lijst opgeslagen
        public List<Position> POICoordinates { get; set; }

        //Hier worden de POI Coordinaten in een lijst opgeslagen
        public List<RouteStartPoint> POIPoints { get; set; }

        public string Url { get; set; }

        public CustomMap ()
		{
			RouteCoordinates = new List<Position> ();
		}
    }
}
