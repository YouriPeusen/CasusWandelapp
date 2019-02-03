using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;
using static CasusWandelapp.BU.Route;
using static CasusWandelapp.BU.MapPageCS;
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
                Label = "First pin try",
                Address = "Adres van de pin",
                Id = "Firstpin"
            };
        }
    }
}