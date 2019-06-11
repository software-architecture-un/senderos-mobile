using Newtonsoft.Json.Linq;
using Rg.Plugins.Popup.Services;
using System;
using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace SenderosMobile
{
    public partial class LoginView : ContentPage
    {
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

            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$"); // Expresión regular de correo electrónico

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
            else if (PasswordEntryField.Text.Length < 6) // Contraseña muy corta
            {
                MessagesPopup messagesPopup = new MessagesPopup(false, 5);
                PopupNavigation.PushAsync(messagesPopup);
            }
            else if(!userResponse.IsLogged(EmailEntryField.Text, PasswordEntryField.Text)) // Correo electrónico y/o contraseña incorrectos
            {
                MessagesPopup messagesPopup = new MessagesPopup(false, 6);
                PopupNavigation.PushAsync(messagesPopup);
            }
            else // Inicio de sesión correcto con usuario existente y su respectiva contraseña
            {
                MainMasterDetailView mainView = new MainMasterDetailView();
                Application.Current.MainPage = mainView;
            }
        }
    }
}
