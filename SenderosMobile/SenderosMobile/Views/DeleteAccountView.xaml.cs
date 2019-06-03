using Rg.Plugins.Popup.Services;
using System;
using Xamarin.Forms;

namespace SenderosMobile.Views
{
	public partial class DeleteAccountView : ContentPage
	{
		public DeleteAccountView ()
		{
			InitializeComponent ();
		}
        
        private void DeleteAccountClicked(object sender, EventArgs e)
        {
            MessagesPopup messagesPopup = new MessagesPopup(true, 2);
            PopupNavigation.PushAsync(messagesPopup);
        }
    }
}