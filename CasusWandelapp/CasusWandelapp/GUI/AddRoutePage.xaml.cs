﻿using CasusWandelapp.Helpers;
using CasusWandelapp.Views;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CasusWandelapp.GUI
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AddRoutePage : ContentPage
	{
		public AddRoutePage ()
		{
			InitializeComponent ();
		}

		private void AddRoutePointButton_Clicked(object sender, EventArgs e)
		{
			AddRouteLabel.Text = "Klik op een punt op de kaart om een punt neer te zetten";
		}
		private void DeleteRoutePointButton_Clicked(object sender, EventArgs e)
		{
			AddRouteLabel.Text = "Klik op een punt om deze te verwijderen";
		}

		private void SaveRouteButton_Clicked(object sender, EventArgs e)
		{
			RouteDB route = new RouteDB()
			{
				RouteName = RouteNameEntry.Text.ToString(),
				RouteLenght = RouteLengthEntry.Text.ToString(),
				RouteDifficulty = RouteDifficultyEntry.Text.ToString()
			};


			using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
			{
				conn.CreateTable<RouteDB>();
				int rows = conn.Insert(route);

				if (rows > 0)
				{
					DisplayAlert("Succes", "Route succesfully added.", "OK");
				}
				else
				{
					DisplayAlert("Failure", "Failed to add Route", "OK");
				}
			}

				Navigation.PushModalAsync(new MyRoutes());
		}
	}
}