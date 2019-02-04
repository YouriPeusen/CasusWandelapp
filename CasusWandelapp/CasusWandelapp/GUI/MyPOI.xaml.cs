using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;
using static CasusWandelapp.BU.Route;
using static CasusWandelapp.BU.POI;
using static CasusWandelapp.BU.CustomPin;
using static CasusWandelapp.BU.CustomMap;

namespace CasusWandelapp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MyPOI: ContentPage
    {
        public MyPOI()
        {
            InitializeComponent();

            var pin = new RouteStartPoint
            {
                Type = PinType.Place,
                Position = new Position(37.797534, -122.401827),
                Label = "Naam POI",
                Address = "Foto",
                Id = "Beschrijving"
            };

            customMap.RouteCoordinates.Add(new Position(37.790126, -122.400360));
            customMap.RouteCoordinates.Add(new Position(37.789250, -122.401451));
            customMap.RouteCoordinates.Add(new Position(37.786736, -122.398202));
            customMap.RouteCoordinates.Add(new Position(37.785983, -122.397295));
            customMap.RouteCoordinates.Add(new Position(37.776831, -122.394627));

            customMap.RouteStartPoints = new List<RouteStartPoint> { pin };
            customMap.Pins.Add(pin);

            customMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(37.79752, -122.40183), Distance.FromMiles(1.0)));
        }
    }
}