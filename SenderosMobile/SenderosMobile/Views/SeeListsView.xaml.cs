using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SenderosMobile.Views
{
	public partial class SeeListsView : ContentPage
	{
        private Place lugarPrueba1;
        private Place lugarPrueba2;
        private List<Place> listaPrueba;

        private PlaceList placeListPrueba1;
        private PlaceList placeListPrueba2;
        private PlaceList placeListPrueba3;
        private PlaceList placeListPrueba4;
        private PlaceList placeListPrueba5;

        private List<PlaceList> listPlaceListsPrueba;

        public SeeListsView ()
		{
			InitializeComponent ();

            lugarPrueba1 = new Place
            {
                Id = 1,
                Name = "Universidad Nacional de Colombia",
                Description = "Universidad blablablabla",
                Address = "Carrera 30, Calle 45",
                Latitude = 5.55,
                Longitude = 5.55,
                PlaceImage = "fdsfdsfsdffd",
                Grade = 5,
                Visits = 0,
            };
            lugarPrueba2 = new Place
            {
                Id = 2,
                Name = "Estadio Nemesio Camacho 'El Campín'",
                Description = "El máximo escenario deportivo de la capital blablablabla",
                Address = "Carrera 30, Calle 57",
                Latitude = 5.56,
                Longitude = 5.56,
                PlaceImage = "qwsadefgd",
                Grade = 5,
                Visits = 3,
            };

            listaPrueba = new List<Place>();
            listaPrueba.Add(lugarPrueba1);
            listaPrueba.Add(lugarPrueba2);

            placeListPrueba1 = new PlaceList()
            {
                Id = 1,
                Name = "Lugares en Bogotá",
                OwnerUser = 1,
                Comment = "La Candelaria y otros.",
                Places = listaPrueba,
                EstimatedDate = "Ayer",
                Order = 1,
                NumberPlaces = listaPrueba.Count,
            };
            placeListPrueba2 = new PlaceList()
            {
                Id = 2,
                Name = "Estadios de Colombia",
                OwnerUser = 1,
                Comment = "Estadios del Mundial Sub-20 2011.",
                Places = listaPrueba,
                EstimatedDate = "Ayer",
                Order = 1,
                NumberPlaces = listaPrueba.Count + 5,
            };
            placeListPrueba3 = new PlaceList()
            {
                Id = 3,
                Name = "Estadios de Inglaterra",
                OwnerUser = 1,
                Comment = "Wembley y otros históricos.",
                Places = listaPrueba,
                EstimatedDate = "Ayer",
                Order = 1,
                NumberPlaces = listaPrueba.Count + 3,
            };
            placeListPrueba4 = new PlaceList()
            {
                Id = 4,
                Name = "Playas en Santa Marta",
                OwnerUser = 1,
                Comment = "Algunas de las más conocidas.",
                Places = listaPrueba,
                EstimatedDate = "Ayer",
                Order = 1,
                NumberPlaces = listaPrueba.Count + 2,
            };
            placeListPrueba5 = new PlaceList()
            {
                Id = 5,
                Name = "Edificios UNAL",
                OwnerUser = 1,
                Comment = "Edificios donde tengo clase.",
                Places = listaPrueba,
                EstimatedDate = "Ayer",
                Order = 1,
                NumberPlaces = listaPrueba.Count,
            };

            listPlaceListsPrueba = new List<PlaceList>
            {
                placeListPrueba1,
                placeListPrueba2,
                placeListPrueba3,
                placeListPrueba4,
                placeListPrueba5,
            };

            PlacesList.ItemsSource = listPlaceListsPrueba;
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