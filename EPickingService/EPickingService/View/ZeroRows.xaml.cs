using EPickingService.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EPickingService.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ZeroRows : ContentPage
    {
        #region Resource
        private string MError = Resource.Resource.MessageError;
        private string IError = Resource.Resource.ErrorInternet;
        private string Ok = Resource.Resource.Okay;
        private string Evalidation = Resource.Resource.ErrorValidation;
        private string Sphoto = Resource.Resource.SelectPhoto;
        private string Photoo = Resource.Resource.Photo;
        private string Storee = Resource.Resource.Store;
        private string Bnumber = Resource.Resource.BoxNumber;
        #endregion End Resource
        public ZeroRows()
        {
            InitializeComponent();
            //((NavigationPage)Application.Current.MainPage).BarBackgroundColor = Color."#a7b409";
            this.BindingContext = new ControllerCamera();
        }

        protected override void OnAppearing()
        {
            try
            {
                base.OnAppearing();
            }
            catch (Exception ex)
            {
                var error = ex.ToString();

            }

        }

        protected override void OnDisappearing()
        {

            try
            {
                base.OnDisappearing();
            }
            catch (Exception ex)
            {
                var error = ex.ToString();
            }
        }

        private async void Btn_sentInfo_Clicked(object sender, EventArgs e)
        {
            try {

                if (String.IsNullOrWhiteSpace(Label_Rutafoto.Text))
                {
                    await this.DisplayAlert(Evalidation, Sphoto+Photoo, Ok);
                }
                else
                {
                    //Valida si el valor en el Entry se encuentra vacio o es igual a Null
                    if (String.IsNullOrWhiteSpace(Tienda_Entry.Text))
                    {
                        await this.DisplayAlert(Evalidation, Storee, Ok);

                    }
                    else
                    {

                        if (String.IsNullOrWhiteSpace(Caja_Entry.Text))
                        {
                            await this.DisplayAlert(Evalidation, Bnumber, Ok);

                        }
                        else
                        {
                            var rutafoto = Label_Rutafoto.Text;
                            var Etienda = Tienda_Entry.Text;
                            var CEntry = Caja_Entry.Text;
                            var Dpfecha = Dpicker_;


                            await DisplayAlert("Los datos", "fueron enviados exitosamente", Ok);


                        }
                    }
                }
            } catch (Exception ex)
            {
                var error = ex.ToString();
            }
        }
    }
}