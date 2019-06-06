using Newtonsoft.Json.Linq;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SenderosMobile.Views
{
    public partial class PlacesView : ContentPage
    {
        public PlacesView()
        {
            InitializeComponent();

            ActivityResponse activityResponse = new ActivityResponse();
            JArray response = activityResponse.AllActivities();
            
            List<Activity> activitiesMappedFromGraphQL = new List<Activity>();

            for(int i = 0; i < response.Count; i++)
            {
                Activity iteratedActivity = new Activity
                {
                    Id = i + 1,
                    Name = response[i].Value<string>("name"),
                    Description = response[i].Value<string>("description"),
                    Calification = response[i].Value<double>("qualification"),
                    Visits = response[i].Value<int>("visits")
                };

                activitiesMappedFromGraphQL.Add(iteratedActivity);
            }

            ActivitiesList.ItemsSource = activitiesMappedFromGraphQL;
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