using ImageCircle.Forms.Plugin.Droid;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace SenderosMobile
{
    public partial class App : Application
    {
        public static MainMasterDetailView MasterDetail { get; set; }

        public App()
        {
            InitializeComponent();

            ImageCircleRenderer.Init();

            LandingView page = new LandingView();
            MainPage = page;
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
