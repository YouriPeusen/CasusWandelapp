using Plugin.Geolocator;
using Plugin.Geolocator.Abstractions;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CasusWandelapp.BU;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static CasusWandelapp.BU.CustomPin;
using Xamarin.Forms.Maps;

namespace CasusWandelapp.BU
{
    class MapPageCS : ContentPage
    {
        public MapPageCS()
        {
            var customMap = new CustomMap
            {
                MapType = MapType.Street,
                WidthRequest = App.ScreenWidth,
                HeightRequest = App.ScreenHeight
            };

            var pin = new CustomPin
            {
                Type = PinType.Place,
                Position = new Xamarin.Forms.Maps.Position(37.79752, -122.40183),
                Label = "Zuyd Hogeschool",
                Address = "Heerlen",
                Id = "POI Zuyd",
                Url = "https://www.zuyd.nl/"

            };
        }
    }
}
