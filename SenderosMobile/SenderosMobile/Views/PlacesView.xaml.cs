using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SenderosMobile.Views
{
    public partial class PlacesView : ContentPage
    {
        private Activity actividadPrueba1;
        private Activity actividadPrueba2;
        private Activity actividadPrueba3;
        private Activity actividadPrueba4;
        private Activity actividadPrueba5;

        private List<Activity> actividadesPrueba;

        public PlacesView()
        {
            InitializeComponent();

            actividadPrueba1 = new Activity()
            {
                Name = "Actividad prueba 1",
                Description = "Solo test",
                Calification = 5,
                Visits = 0,
            };
            actividadPrueba2 = new Activity()
            {
                Name = "Actividad prueba 2",
                Description = "Solo test",
                Calification = 5,
                Visits = 0,
            };
            actividadPrueba3 = new Activity()
            {
                Name = "Actividad prueba 3",
                Description = "Solo test",
                Calification = 5,
                Visits = 0,
            };
            actividadPrueba4 = new Activity()
            {
                Name = "Actividad prueba 4",
                Description = "Solo test",
                Calification = 5,
                Visits = 0,
            };
            actividadPrueba5 = new Activity()
            {
                Name = "Actividad prueba 5",
                Description = "Solo test",
                Calification = 5,
                Visits = 0,
            };

            actividadesPrueba = new List<Activity>
            {
                actividadPrueba1,
                actividadPrueba2,
                actividadPrueba3,
                actividadPrueba4,
                actividadPrueba5,
            };

            ActivitiesList.ItemsSource = actividadesPrueba;
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