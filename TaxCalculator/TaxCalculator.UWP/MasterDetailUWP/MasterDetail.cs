using System;
using System.Collections.Generic;
using System.Text;
using TaxCalculator;
using TaxCalculator.Interface;
using TaxCalculator.MasterDetailUWP;
using Xamarin.Forms;

namespace TaxCalculator.UWP.MasterDetailUWP
{
    public class MasterDetail : MasterDetailPage, IUWPMasterDetail
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

        //Implements the IUWPMasterDetail interface whihc returns MasterDetailPage to set as mainpage for UWP Platfrom only in App.cs in Shared Project.
        public MasterDetailPage GetUWPNavigation()
        {
            return this;
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
                    selectedPage = new TaxCalculator.MainPage();
                    break;
                case PageType.Test:
                    selectedPage = new TaxCalculator.MainPage();
                    break;
                case PageType.About:
                    selectedPage = new TaxCalculator.MainPage();
                    break;
                case PageType.Setting:
                    selectedPage = new TaxCalculator.View.SettingView();
                    break;
            }
            NavigationPage.SetHasNavigationBar(selectedPage, false);
            this.Detail = new NavigationPage(selectedPage);
            try
            {
                IsPresented = false;
            }
            catch { }
        }
    }
}
