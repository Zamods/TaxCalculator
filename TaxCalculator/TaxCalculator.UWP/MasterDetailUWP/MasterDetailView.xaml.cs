using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TaxCalculator.UWP.MasterDetailUWP
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MasterDetailView : ContentPage
	{
		public MasterDetailView (MasterDetailViewModel viewModel)
		{
			InitializeComponent ();
            this.BindingContext = viewModel;
		}

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            DisplayAlert("Gone", "Soooe", "ok");
        }
    }
}