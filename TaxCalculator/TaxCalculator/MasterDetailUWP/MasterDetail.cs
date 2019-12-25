using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace TaxCalculator.MasterDetailUWP
{
    public class MasterDetail : MasterDetailPage
    {
        public MasterDetail()
        {
            var viewModel = new MasterDetailViewModel();
            var master = new MasterDetailView(viewModel);
            this.Master = master;
            this.MasterBehavior = MasterBehavior.Split;
            viewModel.PageSelected += MasterPageSelected;
            PresentDetailPage(PageType.Home);
        }

        void MasterPageSelected(object sender, PageType page)
        {
            PresentDetailPage(page);
        }

        void PresentDetailPage(PageType page)
        {
            Page selectedPage;
            switch (page)
            {
                case PageType.Home:
                default:
                    selectedPage = new TaxCalculator.MasterDetail();
                    break;
                case PageType.Test:
                    selectedPage = new TaxCalculator.MasterDetail();
                    break;
                case PageType.About:
                    selectedPage = new TaxCalculator.MasterDetail();
                    break;
            }
            var navPage= new NavigationPage(selectedPage);
            NavigationPage.SetHasNavigationBar(navPage, false);
            this.Detail = navPage;
            try
            {
                IsPresented = false;
            }
            catch { }
        }
    }
}
