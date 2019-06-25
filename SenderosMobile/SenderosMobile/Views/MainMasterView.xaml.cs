using SenderosMobile.Views;
using System;
using Xamarin.Forms;

namespace SenderosMobile
{
	public partial class MainMasterView : ContentPage
	{
		public MainMasterView ()
		{
			InitializeComponent ();

            UserResponse userResponse = new UserResponse();

            User currentUser = userResponse.UserEmail(Application.Current.Properties["email"].ToString());

            NameLogged.Text = currentUser.Name;
        }

        private void ModifyUserClicked(object sender, EventArgs e)
        {
            App.MasterDetail.IsPresented = false;
            App.MasterDetail.Detail = new NavigationPage(new ModifyUserView());
        }

        private void ListsClicked(object sender, EventArgs e)
        {
            App.MasterDetail.IsPresented = false;
            App.MasterDetail.Detail = new NavigationPage(new ListsView());
        }

        private void RoutesClicked(object sender, EventArgs e)
        {
            App.MasterDetail.IsPresented = false;
            App.MasterDetail.Detail = new NavigationPage(new RoutesView());
        }

        private void LogoutClicked(object sender, EventArgs e)
        {
            Application.Current.Properties["jwt"] = "";
            Application.Current.Properties["email"] = "";

            LandingView loginView = new LandingView();
            Application.Current.MainPage = loginView;
        }
    }
}