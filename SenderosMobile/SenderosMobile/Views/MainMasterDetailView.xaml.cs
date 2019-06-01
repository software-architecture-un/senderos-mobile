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

            MainMasterView master = new MainMasterView();
            MainDetailView detail = new MainDetailView();

            this.Master = master;
            this.Detail = new NavigationPage(detail);
		}
	}
}