﻿using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace CasusWandelapp
{
    public partial class App : Application
    {
		public static double ScreenHeight;
		public static double ScreenWidth;
		public static string DatabaseLocation = string.Empty;


		public App(string databaseLocation)
        {
            InitializeComponent();
			MainPage = new NavigationPage(new LoginPage());

			DatabaseLocation = databaseLocation;
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
