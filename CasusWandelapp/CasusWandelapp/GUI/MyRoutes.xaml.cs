using CasusWandelapp.GUI;
using CasusWandelapp.Helpers;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace CasusWandelapp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MyRoutes : ContentPage
	{
		public ObservableCollection<RouteDB> routes { get; set; }

		public MyRoutes ()
		{
			InitializeComponent();

			using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
			{
				routes = new ObservableCollection<RouteDB>();
				List<RouteDB> routelist = conn.Table<RouteDB>().ToList();

				foreach(RouteDB a in routelist)
				{
					routes.Add(a);
				}

				routeListView.ItemsSource = routes;
			}

		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
			//using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
			//{
			//	conn.CreateTable<RouteDB>();

			//	var routelist = conn.Table<RouteDB>().ToList();
			//	var routeNameList = conn.Query<RouteDB>("SELECT RouteName FROM RouteDB");


			//	List<string> routelist = (List<string>)conn.
			//	List < RouteDB > routelist = conn.Table<RouteDB>().ToList();
			//	List<string> routelist2 = new List<string>();

			//	foreach (RouteDB a in routelist)
			//	{
			//		routelist2.Add(Convert.ToString(a));
			//	}

			//	routeListView.ItemsSource = routelist;
			//}
		}

		private void AddRouteButton_Clicked(object sender, EventArgs e)
		{
			Navigation.PushModalAsync(new AddRoutePage());
		}
	}
}