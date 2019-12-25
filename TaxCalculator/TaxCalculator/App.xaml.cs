using System;
using TaxCalculator.MasterDetailUWP;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace TaxCalculator
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            // Initialize Live Reload.
            LiveReload.Init();
            InitializeNavigation();
        }

        public static void InitializeNavigation()
        {
#if DEBUG

#if __ANDROID__
            Current.MainPage = new  MasterDetailShell.AppShell();
#elif __IOS__
            Current.MainPage = new  MasterDetailShell.AppShell();
#else
            Current.MainPage = DependencyService.Get<Interface.IUWPMasterDetail>().GetUWPNavigation();
#endif
#endif
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
