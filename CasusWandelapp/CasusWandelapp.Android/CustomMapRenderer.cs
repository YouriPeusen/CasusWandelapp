using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using CasusWandelapp.BU;
using CasusWandelapp.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Maps.Android;
using static CasusWandelapp.BU.Route;


[assembly: ExportRenderer(typeof(CustomMap), typeof(CustomMapRenderer))]
namespace CasusWandelapp.Droid
{
	public class CustomMapRenderer : MapRenderer
	{
		List<Position> routeCoordinates;
		List<RouteStartPoint> routeStartPoints;

		public CustomMapRenderer(Context context) : base(context)
		{

		}

		protected override void OnElementChanged(Xamarin.Forms.Platform.Android.ElementChangedEventArgs<Map> e)
		{
			base.OnElementChanged(e);

			if (e.OldElement != null)
			{
				NativeMap.InfoWindowClick -= OnInfoWindowClick;
			}

			if (e.NewElement != null)
			{
				var formsMap = (CustomMap)e.NewElement;
				routeCoordinates = formsMap.RouteCoordinates;
				routeStartPoints = formsMap.RouteStartPoints;
				Control.GetMapAsync(this);
			}
		}

		protected override void OnMapReady(GoogleMap map)
		{
			base.OnMapReady(map);
			NativeMap.InfoWindowClick += OnInfoWindowClick;
		}
		

		protected override MarkerOptions CreateMarker(Pin pin)
		{
			var marker = new MarkerOptions();
			marker.SetPosition(new LatLng(pin.Position.Latitude, pin.Position.Longitude));
			marker.SetTitle(pin.Label);
			marker.SetSnippet(pin.Address);
			return marker;
		}

		void OnInfoWindowClick(object sender, GoogleMap.InfoWindowClickEventArgs e)
		{
			var routeStartPoint = GetCustomPin(e.Marker);
			if (routeStartPoint == null)
			{
				throw new Exception("Custom pin not found");
			}

			if (!string.IsNullOrWhiteSpace(routeStartPoint.Url))
			{
				var url = Android.Net.Uri.Parse(routeStartPoint.Url);
				var intent = new Intent(Intent.ActionView, url);
				intent.AddFlags(ActivityFlags.NewTask);
				Android.App.Application.Context.StartActivity(intent);
			}
			
			var polylineOptions = new PolylineOptions();
			polylineOptions.InvokeColor(0x66FF0000);

			foreach (var position in routeCoordinates)
			{
				polylineOptions.Add(new LatLng(position.Latitude, position.Longitude));
			}

			NativeMap.AddPolyline(polylineOptions);
		}

		public Android.Views.View GetInfoWindow(Marker marker)
		{
			return null;
		}

		RouteStartPoint GetCustomPin(Marker annotation)
		{
			var position = new Position(annotation.Position.Latitude, annotation.Position.Longitude);
			foreach (var pin in routeStartPoints)
			{
				if (pin.Position == position)
				{
					return pin;
				}
			}
			return null;
		}
	}
}