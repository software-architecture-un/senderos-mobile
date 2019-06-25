using Newtonsoft.Json.Linq;
using Rg.Plugins.Popup.Services;
using System;
using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace SenderosMobile
{
    public partial class LoginView : ContentPage
    {
        GlobalVariables Variables = new GlobalVariables();

        public LoginView()
        {
            InitializeComponent();

        }

        private void BackClicked(object sender, EventArgs e)
        {
            LandingView landingView = new LandingView();
            Application.Current.MainPage = landingView;
        }

        private void LoginClicked(object sender, EventArgs e)
        {
            UserResponse userResponse = new UserResponse(); // Para hacer queries a User

            Regex regex = Variables.EmailFormat; // Expresión regular de correo electrónico

            if (EmailEntryField.Text == "" || EmailEntryField.Text == null || PasswordEntryField.Text == "" || PasswordEntryField.Text == null) // Campos vacíos
            {
                MessagesPopup messagesPopup = new MessagesPopup(false, 3);
                PopupNavigation.PushAsync(messagesPopup);
            }
            else if (!regex.Match(EmailEntryField.Text).Success) // Correo electrónico con formato errado
            {
                MessagesPopup messagesPopup = new MessagesPopup(false, 4);
                PopupNavigation.PushAsync(messagesPopup);
            }
            else if (PasswordEntryField.Text.Length < Variables.MinLengthPassword) // Contraseña muy corta
            {
                MessagesPopup messagesPopup = new MessagesPopup(false, 5);
                PopupNavigation.PushAsync(messagesPopup);
            }
            else
            {
                string jwt = userResponse.LogIn(EmailEntryField.Text, PasswordEntryField.Text);

                if(jwt == "") // Si no se generó JWT
                {
                    MessagesPopup messagesPopup = new MessagesPopup(false, 6);
                    PopupNavigation.PushAsync(messagesPopup);
                }
                else // Inicio de sesión correcto con usuario existente y su respectiva contraseña
                {
                    Application.Current.Properties["jwt"] = jwt;
                    Application.Current.Properties["email"] = EmailEntryField.Text;

                    MainMasterDetailView mainView = new MainMasterDetailView();
                    Application.Current.MainPage = mainView;
                }
            }
        }
    }
}
