using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SenderosMobile
{
	public partial class MainMasterDetailView : MasterDetailPage
    {
		public MainMasterDetailView ()
		{
			InitializeComponent ();

            this.Master = new MainMasterView();
            this.Detail = new NavigationPage(new ModifyUserView());

            App.MasterDetail = this;
		}
	}
}