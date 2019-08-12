using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EPickingService.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MasterDetail : MasterDetailPage, INotifyPropertyChanged
    {
		public MasterDetail ()
		{
			InitializeComponent ();
		}

    

        private void ZeroRows_Clicked(object sender, EventArgs e)
        {
            try
            {
                Detail = new NavigationPage(new ZeroRows());
                Detail = Detail;
                IsPresented = false; //Esconden 
            }
            catch(Exception ex)
            {
                var error = ex.ToString();
            }
        }
        private void Namesalir_Clicked(object sender, EventArgs e)
        {
            try
            {
                App.Current.MainPage = new MainPage();
              
            }
            catch (Exception ex)
            {
                var error = ex.ToString();

            }
        }
    }
}