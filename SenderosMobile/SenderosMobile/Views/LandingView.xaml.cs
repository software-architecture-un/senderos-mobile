using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SenderosMobile
{
	public partial class LandingView : ContentPage
	{
		public LandingView()
		{
            InitializeComponent();
		}

        private void SignInClicked(object sender, EventArgs e)
        {
            LoginView loginView = new LoginView();
            Application.Current.MainPage = loginView;
        }
	}
}