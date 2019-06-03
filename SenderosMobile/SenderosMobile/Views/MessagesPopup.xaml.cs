using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using SenderosMobile.Views;
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
        private bool isSuccessOrNot;
        private int pressOrigin;

        private string popupMessage1Success;
        private string popupMessage1Error;
        private string popupMessage2Success;
        private string popupMessage2Error;

        public MessagesPopup (bool isSuccess, int origin)
		{
			InitializeComponent ();

            isSuccessOrNot = isSuccess;
            pressOrigin = origin;

            ResourceManager resourceManager = new ResourceManager("SenderosMobileLanguage.Resx.TextResources", typeof(SenderosMobileLanguage.Class1).Assembly);
            popupMessage1Success = resourceManager.GetString("PopupMessage1Success");
            popupMessage1Error = resourceManager.GetString("PopupMessage1Error");
            popupMessage2Success = resourceManager.GetString("PopupMessage2Success");
            popupMessage2Error = resourceManager.GetString("PopupMessage2Error");

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
            if (isSuccess) // Caso de éxito
            {
                switch (origin)
                {
                    case 1: // Crear cuenta
                        this.PopupMessage.Text = popupMessage1Success;
                        break;
                    case 2: // Crear cuenta
                        this.PopupMessage.Text = popupMessage2Success;
                        break;
                    default:
                        this.PopupMessage.Text = "";
                        break;
                }
            }
            else
            {
                switch (origin) // Error
                {
                    case 1:
                        this.PopupMessage.Text = popupMessage1Error;
                        break;
                    case 2: // Crear cuenta
                        this.PopupMessage.Text = popupMessage2Error;
                        break;
                    default:
                        this.PopupMessage.Text = "";
                        break;
                }
            }
        }
        
        private void PopupButtonClicked(object sender, EventArgs e)
        {
            if (isSuccessOrNot) // Caso de éxito
            {
                switch (pressOrigin)
                {
                    case 1: // Crear cuenta
                        LoginView loginView = new LoginView();
                        Application.Current.MainPage = loginView;

                        PopupNavigation.PopAsync();
                        break;
                    case 2: // Eliminar cuenta
                        LandingView landingView = new LandingView();
                        Application.Current.MainPage = landingView;

                        PopupNavigation.PopAsync();
                        break;
                    default:
                        break;
                }
            }
            else // Error
            {
                switch (pressOrigin)
                {
                    case 1: // Crear cuenta

                        PopupNavigation.PopAsync();
                        break;
                    case 2: // Eliminar cuenta

                        PopupNavigation.PopAsync();
                        break;
                    default:
                        break;
                }
            }            
        }
    }
}