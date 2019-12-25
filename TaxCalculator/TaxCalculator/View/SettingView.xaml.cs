using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TaxCalculator.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SettingView : ContentPage
	{
		public SettingView ()
		{
			InitializeComponent ();
		}

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await MenuIcon.RelRotateTo(45.0, 250, Easing.CubicIn);
            await MenuIcon.RelRotateTo(-45.0, 250, Easing.SpringOut);
        }
    }
}