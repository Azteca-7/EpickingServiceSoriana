using EPickingService.View;
using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace EPickingService
{
    public partial class MainPage : ContentPage
    {
        #region Resource
        private string MError = Resource.Resource.MessageError;
        private string IError = Resource.Resource.ErrorInternet;
        private string Ok = Resource.Resource.Okay;
        private string Evalidation = Resource.Resource.ErrorValidation;
        private string Ruser = Resource.Resource.RequiredUser;
        private string Rpass = Resource.Resource.RequiredPass;
        #endregion End Resource
        public MainPage()
        {
            InitializeComponent();
        }
        public async void btnlogin_btn(object sender, EventArgs e)
        {
            try
            {
                //Check network status   
                if (!CrossConnectivity.Current.IsConnected)

                 await DisplayAlert(MError, IError, Ok);
                else

                {
                    if (String.IsNullOrWhiteSpace(User_Entry.Text))
                    {
                        await DisplayAlert(Evalidation, Ruser, Ok);

                    }

                    else
                    {
                        //Valida que el formato del correo sea valido
                        bool isEmail = Regex.IsMatch(User_Entry.Text, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);
                        if (!isEmail)
                        {
                            await DisplayAlert(Evalidation, "El formato del correo electrónico es incorrecto, revíselo e intente de nuevo.", Ok);

                        }
                        else
                        {
                            if (String.IsNullOrWhiteSpace(Password_Entry.Text))
                            {
                                await DisplayAlert(Evalidation, Rpass, Ok);
                            }
                            else
                            {

                                string user_ = User_Entry.Text;
                                string pass_ = Password_Entry.Text;
                                // var token = new ServiceActions().DoLogin("user4", "password", false);
                                //var token = new ServiceActions().DoLogin(user_, pass_, false);
                                //if (!string.IsNullOrEmpty(token.Access_token))
                                //{
                                //    var jornada = new ServiceActions().GetJornada(token.Access_token);

                               // await Navigation.PushAsync(new MasterDetail());
                                App.Current.MainPage = new MasterDetail();
                                // }
                                //else
                                //{
                                //    DisplayAlert("¡Usuario no encontrado!", "Intente de nuevo", "Ok");
                                //}
                            }
                        }
                    }
                }


            }
            catch (Exception ex)
            {
                var Error = ex.ToString();
                await DisplayAlert(MError, Error, Ok);
            }
        }
    }
}
