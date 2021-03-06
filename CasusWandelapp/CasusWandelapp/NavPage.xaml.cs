﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CasusWandelapp.Views;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CasusWandelapp
{
    public partial class NavPage : MasterDetailPage
    {
		public List<MasterPageItem> Menulist { get; set; }

        public NavPage()
        {
            InitializeComponent();

			Menulist = new List<MasterPageItem>();

			var page1 = new MasterPageItem() { Title = "Map", TargetType = typeof(MainPage) };
			var page2 = new MasterPageItem() { Title = "Mijn Routes", TargetType = typeof(MyRoutes) };
			var page3 = new MasterPageItem() { Title = "Mijn POI's", TargetType = typeof(MyPOI) };
			var page4 = new MasterPageItem() { Title = "Historie", TargetType = typeof(History) };
			var page5 = new MasterPageItem() { Title = "Uitloggen", TargetType = typeof(LoginPage) };
			var page6 = new MasterPageItem() { Title = "Test Map", TargetType = typeof(RouteTryOut) };

			Menulist.Add(page1);
			Menulist.Add(page2);
			Menulist.Add(page3);
			Menulist.Add(page4);
			Menulist.Add(page5);
			Menulist.Add(page6);

			navigationDrawerList.ItemsSource = Menulist;

			Detail = new NavigationPage((Page)Activator.CreateInstance(typeof(MainPage)));

			this.BindingContext = new
			{
				Header = "Wandelapp"
			};
		}

        private void NavigationDrawerList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
			var Item = (MasterPageItem)e.SelectedItem;
			Type page = Item.TargetType;

			Detail = new NavigationPage((Page)Activator.CreateInstance(page));
			IsPresented = false;
		}
	}
}