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
using static CasusWandelapp.BU.CustomMap;

namespace CasusWandelapp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MyPOI: ContentPage
    {
        public MyPOI()
        {
            InitializeComponent();

            //Toevoegen van pin op map
            var pin = new RouteStartPoint
            {
                Type = PinType.Place,
                Position = new Position(37.797534, -122.401827),
                Label = "Naam POI",
                Address = "Foto",
                Id = "Beschrijving"
            };

            //Toevoegen van coordinaten 
            customMap.POICoordinates.Add(new Position(37.790136, -122.400236));
            customMap.POICoordinates.Add(new Position(37.789345, -122.401253));
            customMap.POICoordinates.Add(new Position(37.786264, -122.398471));
            customMap.POICoordinates.Add(new Position(37.785942, -122.397357));
            customMap.POICoordinates.Add(new Position(37.776824, -122.394353));
                        
            //Points toevoegen aan lijst
            customMap.POIPoints = new List<RouteStartPoint> { pin };
            customMap.Pins.Add(pin);

            customMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(37.786264, -122.398471), Distance.FromMiles(1.0)));
        }
    }
}