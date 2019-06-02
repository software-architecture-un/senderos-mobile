using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SenderosMobile
{
	public partial class MessagesPopup : PopupPage
	{
        private int pressOrigin;

        private string popupMessage1Success;
        private string popupMessage1Error;

        public MessagesPopup (bool isSuccess, int origin)
		{
			InitializeComponent ();

            pressOrigin = origin;

            ResourceManager resourceManager = new ResourceManager("SenderosMobileLanguage.Resx.TextResources", typeof(SenderosMobileLanguage.Class1).Assembly);
            popupMessage1Success = resourceManager.GetString("PopupMessage1Success");
            popupMessage1Error = resourceManager.GetString("PopupMessage1Error");

            this.BackgroundColor = Color.FromRgba(0, 0, 0, 0.7);

            SelectImage(isSuccess);
            SelectMessage(isSuccess, origin);

            this.PopupButton.Clicked += new EventHandler(PopupButtonClicked);
        }

        private void SelectImage(bool isSuccess)
        {
            if(isSuccess)
            {
                this.PopupImage.Source = "check.png";
            }
            else
            {
                this.PopupImage.Source = "cross.png";
            }
        }

        private void SelectMessage(bool isSuccess, int origin)
        {
            if (isSuccess)
            {
                switch (origin)
                {
                    case 1:
                        this.PopupMessage.Text = popupMessage1Success;
                        break;
                    default:
                        this.PopupMessage.Text = "";
                        break;
                }
            }
            else
            {
                switch (origin)
                {
                    case 1:
                        this.PopupMessage.Text = popupMessage1Error;
                        break;
                    default:
                        this.PopupMessage.Text = "";
                        break;
                }
            }
        }

        //PopupButton
        private void PopupButtonClicked(object sender, EventArgs e)
        {
            switch (pressOrigin)
            {
                case 1:
                    LoginView loginView = new LoginView();
                    Application.Current.MainPage = loginView;

                    PopupNavigation.PopAsync();
                    break;
                default:
                    break;
            }

            
        }
    }
}