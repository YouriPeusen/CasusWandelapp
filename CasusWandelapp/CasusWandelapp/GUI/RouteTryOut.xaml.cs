using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;
using static CasusWandelapp.BU.Route;
using static CasusWandelapp.BU.CustomMap;



namespace CasusWandelapp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class RouteTryOut : ContentPage
	{
		public RouteTryOut ()
		{
			InitializeComponent();

			var pin = new RouteStartPoint
			{
				Type = PinType.Place,
				Position = new Position(37.797235, -122.401352),
				Label = "First pin try",
				Address = "Adres van de pin",
				Id = "Firstpin"
			};

			customMap.RouteCoordinates.Add(new Position(37.797534, -122.401827));
			customMap.RouteCoordinates.Add(new Position(37.797510, -122.402060));
			customMap.RouteCoordinates.Add(new Position(37.790269, -122.400589));
			customMap.RouteCoordinates.Add(new Position(37.790265, -122.400474));
			customMap.RouteCoordinates.Add(new Position(37.790228, -122.400391));
			customMap.RouteCoordinates.Add(new Position(37.790126, -122.400360));
			customMap.RouteCoordinates.Add(new Position(37.789250, -122.401451));
			customMap.RouteCoordinates.Add(new Position(37.788440, -122.400396));
			customMap.RouteCoordinates.Add(new Position(37.787999, -122.399780));
			customMap.RouteCoordinates.Add(new Position(37.786736, -122.398202));
			customMap.RouteCoordinates.Add(new Position(37.786345, -122.397722));
			customMap.RouteCoordinates.Add(new Position(37.785983, -122.397295));
			customMap.RouteCoordinates.Add(new Position(37.785559, -122.396728));
			customMap.RouteCoordinates.Add(new Position(37.780624, -122.390541));
			customMap.RouteCoordinates.Add(new Position(37.777113, -122.394983));
			customMap.RouteCoordinates.Add(new Position(37.776831, -122.394627));

			customMap.RouteStartPoints = new List<RouteStartPoint> { pin };
			customMap.Pins.Add(pin);

			customMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(37.79752, -122.40183), Distance.FromMiles(1.0)));
		}
	}
}