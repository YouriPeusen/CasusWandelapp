﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CasusWandelapp
{
	public partial class LoginPage : ContentPage
	{
		public LoginPage ()
		{
			InitializeComponent ();
		}

        private void LoginButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new NavPage());
        }
    }
}