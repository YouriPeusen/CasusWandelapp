using CasusWandelapp.GUI;
using System;
using System.Collections.Generic;
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
		public MyRoutes ()
		{
			InitializeComponent();
		}

		private void AddRouteButton_Clicked(object sender, EventArgs e)
		{
			Navigation.PushModalAsync(new AddRoutePage());
		}
	}
}