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
		}

        private void ModifyUserClicked(object sender, EventArgs e)
        {
            App.MasterDetail.IsPresented = false;
            App.MasterDetail.Detail = new NavigationPage(new ModifyUserView());
        }

        private void CreateListClicked(object sender, EventArgs e)
        {
            App.MasterDetail.IsPresented = false;
            App.MasterDetail.Detail = new NavigationPage(new CreateListView());
        }

        private void SeeListsClicked(object sender, EventArgs e)
        {
            App.MasterDetail.IsPresented = false;
            App.MasterDetail.Detail = new NavigationPage(new SeeListsView());
        }

        private void PlacesClicked(object sender, EventArgs e)
        {
            App.MasterDetail.IsPresented = false;
            App.MasterDetail.Detail = new NavigationPage(new PlacesView());
        }

        private void DeleteAccountClicked(object sender, EventArgs e)
        {
            App.MasterDetail.IsPresented = false;
            App.MasterDetail.Detail = new NavigationPage(new DeleteAccountView());
        }

        private void LogoutClicked(object sender, EventArgs e)
        {
            LandingView loginView = new LandingView();
            Application.Current.MainPage = loginView;
        }
    }
}