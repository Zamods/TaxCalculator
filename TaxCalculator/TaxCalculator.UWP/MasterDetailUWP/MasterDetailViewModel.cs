using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using TaxCalculator.MasterDetailUWP;
using Xamarin.Forms;

namespace TaxCalculator.UWP.MasterDetailUWP
{
    public class MasterDetailViewModel
    {
        public EventHandler<PageType> PageSelected;
        public ICommand NavigateToPage { get; private set; }

        public MasterDetailViewModel()
        {
            NavigateToPage = new Command<string>(p => InvokeNavigation(p));
        }

        void InvokeNavigation(string page)
        {
            switch (page)
            {
                case "Home":
                    PageSelected?.Invoke(this, PageType.Home);
                    break;
                case "About":
                    PageSelected?.Invoke(this, PageType.About);
                    break;
                case "Test":
                    PageSelected?.Invoke(this, PageType.Test);
                    break;
                case "Setting":
                    PageSelected?.Invoke(this, PageType.Setting);
                    break;
            }
        }

    }
}
