using Newtonsoft.Json.Linq;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SenderosMobile.Views
{
    public partial class RoutesView : ContentPage
    {
        public RoutesView()
        {
            InitializeComponent();

            TrailResponse trailResponse = new TrailResponse();

            UserResponse userResponse = new UserResponse();
            User currentUser = userResponse.UserEmail(Application.Current.Properties["email"].ToString());

            List<Trail> trails = trailResponse.AllTrailsMapped(currentUser.Id);

            ActivitiesList.ItemsSource = trails;
        }

        private void ListsViewItemTapped(object sender, ItemTappedEventArgs e)
        {
            ((ListView)sender).SelectedItem = null;
        }

        private void OpenList(object sender, EventArgs e)
        {
            Button buttton = (Button)sender;
            long idSelectedList = (long)buttton.CommandParameter;

            PopupNavigation.PushAsync(new MessagesPopup(true, 1));
        }
    }
}