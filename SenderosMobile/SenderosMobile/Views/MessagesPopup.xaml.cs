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

        private string loginErrorMessage1;
        private string loginErrorMessage2;
        private string loginErrorMessage3;
        private string loginErrorMessage4;

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

            loginErrorMessage1 = resourceManager.GetString("LoginErrorMessage1");
            loginErrorMessage2 = resourceManager.GetString("LoginErrorMessage2");
            loginErrorMessage3 = resourceManager.GetString("LoginErrorMessage3");
            loginErrorMessage4 = resourceManager.GetString("LoginErrorMessage4");

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
                    case 3: // Login campos vacíos
                        this.PopupMessage.Text = loginErrorMessage1;
                        break;
                    case 4: // Login email sin formato correcto
                        this.PopupMessage.Text = loginErrorMessage2;
                        break;
                    case 5: // Login contraseña corta
                        this.PopupMessage.Text = loginErrorMessage3;
                        break;
                    case 6: // Login email o contraseña incorrectos
                        this.PopupMessage.Text = loginErrorMessage4;
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
                    case 3: // Login campos vacíos

                        PopupNavigation.PopAsync();
                        break;
                    case 4: // Login email sin formato correcto

                        PopupNavigation.PopAsync();
                        break;
                    case 5: // Login contraseña corta

                        PopupNavigation.PopAsync();
                        break;
                    case 6: // Login email o contraseña incorrectos

                        PopupNavigation.PopAsync();
                        break;
                    default:
                        break;
                }
            }            
        }
    }
}