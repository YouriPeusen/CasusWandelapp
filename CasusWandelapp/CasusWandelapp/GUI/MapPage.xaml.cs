using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CasusWandelapp.BU;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace CasusWandelapp.GUI
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MapPage : ContentPage
	{
        public MapPage()
        {
            InitializeComponent();
            var pin = new CustomPin
            {
                Type = PinType.Place,
                Position = new Position(50.879601, 5.959589),
                Label = "Zuyd Hogeschool",
                Address = "Heerlen",
                Id = "Xamarin",
                Url = "http://xamarin.com/about/"
            };

            customMap.CustomPins = new List<CustomPin> { pin };
            customMap.Pins.Add(pin);
            customMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(50.879601, 5.959589), Distance.FromMiles(1.0)));
        }
    }
}