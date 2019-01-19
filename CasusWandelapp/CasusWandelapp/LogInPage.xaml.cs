using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CasusWandelapp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LogInPage : ContentPage
	{
		public LogInPage()
		{
			InitializeComponent();
		}
        
        private void LoginButton_Clicked(object sender, EventArgs e)
        {
            //bool isEmailEmpty = string.IsNullOrEmpty(emailEntry.Text);
            //bool isPasswordEmpty = string.IsNullOrEmpty(passwordEntry.Text);

            //if (isEmailEmpty || isPasswordEmpty)
            //{
            //    loginLabel.Text = "Login Failed";
            //}
            //else
            //{
                Navigation.PushAsync(new MainPage());
            //}
        }
    }
}