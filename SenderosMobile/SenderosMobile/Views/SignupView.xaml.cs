using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SenderosMobile.Views
{
	public partial class SignupView : ContentPage
	{
        private List<string> AgeList = new List<string>();
        private List<string> GenderList = new List<string>();

        public SignupView ()
		{
			InitializeComponent ();

            InitializeAge();
            InitializeGender();

            AgePicker.ItemsSource = AgeList;
            GenderPicker.ItemsSource = GenderList;
		}

        private void InitializeAge()
        {
            for(int i = 12; i <= 130; i++)
            {
                AgeList.Add(i.ToString());
            }
        }

        private void InitializeGender()
        {
            GenderList.Add("Female");
            GenderList.Add("Male");
        }

        private void BackClicked(object sender, EventArgs e)
        {
            LandingView landingView = new LandingView();
            Application.Current.MainPage = landingView;
        }

        private void SignupClicked(object sender, EventArgs e)
        {
            MessagesPopup messagesPopup = new MessagesPopup(true, 1);
            PopupNavigation.PushAsync(messagesPopup);
        }
    }
}