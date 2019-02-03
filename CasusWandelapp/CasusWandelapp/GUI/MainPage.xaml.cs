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
using Xamarin.Forms.Maps;
using static CasusWandelapp.BU.Route;

namespace CasusWandelapp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        private bool hasLocationPermission = false;

        public MainPage()
        {
			//Onderstaande fucntie zou de data uit de database halen
			BU.Route oRoute = new Route();
			oRoute.ShowRoutes();

			InitializeComponent();

			//Omdat er geen gebruik wordt gemaakt van een database wordt de data hardcoded meegegeven
			var pin = new RouteStartPoint
			{
				Type = PinType.Place,
				Position = new Xamarin.Forms.Maps.Position(50.881152, 5.960432),
				Label = "First pin try",
				Address = "Adres van de pin",
				Id = "Firstpin"
			};

			locationsMap.RouteCoordinates.Add(new Xamarin.Forms.Maps.Position(50.880908, 5.960432));
			locationsMap.RouteCoordinates.Add(new Xamarin.Forms.Maps.Position(50.879798, 5.960218));
			locationsMap.RouteCoordinates.Add(new Xamarin.Forms.Maps.Position(50.878173, 5.963565));

			locationsMap.RouteStartPoints = new List<RouteStartPoint> { pin };
			locationsMap.Pins.Add(pin);
			GetPermissions();
		}

		private async void GetPermissions()
        {
            try
            {
                var status = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.LocationWhenInUse);

                if (status != PermissionStatus.Granted)
                {
                    if (await CrossPermissions.Current.ShouldShowRequestPermissionRationaleAsync(Permission.LocationWhenInUse))
                    {
                        await DisplayAlert("Need you location", "We need to access your location", "OK");
                    }

                    var results = await CrossPermissions.Current.RequestPermissionsAsync(Permission.LocationWhenInUse);

                    if (results.ContainsKey(Permission.LocationWhenInUse))
                    {
                        status = results[Permission.LocationWhenInUse];
                    }
                }

                if (status == PermissionStatus.Granted)
                {
                    hasLocationPermission = true;
                    locationsMap.IsShowingUser = true;

                    GetLocation();
                }

                else
                {
                    await DisplayAlert("Location denied", "You didn't give us permission to access your location, so we can't show you", "OK");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "OK");
            }
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            if (hasLocationPermission)
            {
                var locator = CrossGeolocator.Current;
                locator.PositionChanged += Locator_PositionChanged;
                await locator.StartListeningAsync(TimeSpan.Zero, 100);
            }

			GetLocation();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            CrossGeolocator.Current.StopListeningAsync();
            CrossGeolocator.Current.PositionChanged -= Locator_PositionChanged;
        }

        void Locator_PositionChanged(object sender, PositionEventArgs e)
        {
			MoveMap(e.Position);
        }

        private async void GetLocation()
        {
            if (hasLocationPermission)
            {
                var locator = CrossGeolocator.Current;
                var position = await locator.GetPositionAsync();

                MoveMap(position);
            }
        }

        private void MoveMap(Plugin.Geolocator.Abstractions.Position position)
        {
            var center = new Xamarin.Forms.Maps.Position(position.Latitude, position.Longitude);
            var span = new Xamarin.Forms.Maps.MapSpan(center, 1, 1);
            locationsMap.MoveToRegion(span);
        }

		private void ToolbarItem_Clicked(object sender, EventArgs e)
		{

		}
	}
}
