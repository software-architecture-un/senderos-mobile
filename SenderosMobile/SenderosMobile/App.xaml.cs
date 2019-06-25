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

            UserResponse userResponse = new UserResponse(); // Para hacer queries a User

            if(Current.Properties["jwt"] == null || Current.Properties["jwt"].ToString() == "")
            {
                MainPage = new LandingView();
            }
            else
            {
                if(userResponse.VerifyToken(Current.Properties["jwt"].ToString()))
                {
                    MainPage = new MainMasterDetailView();
                }
                else
                {
                    MainPage = new LandingView();
                }
            }
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
