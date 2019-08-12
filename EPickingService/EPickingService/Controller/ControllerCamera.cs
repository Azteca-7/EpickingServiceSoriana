using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace EPickingService.Controller
{
   public class ControllerCamera : BindableObject
    {
        public static readonly BindableProperty RutaFotoProperty = BindableProperty.Create(
                                  "RutaFoto",
                                  typeof(string),
                                  typeof(ControllerCamera),
                                  default(string));
        public string RutaFoto
        {
            
                get
            {
                    return (string)GetValue(RutaFotoProperty);
                }
                set
            {
                    SetValue(RutaFotoProperty, value);
                }
            
        }
        private MediaFile Foto;
        public Command m_seleccionarFotoComand;

        public Command SeleccionarFotoComand
        {
            get
            {
                return (m_seleccionarFotoComand ?? (m_seleccionarFotoComand = new Command(async () => await SelectphotoAsync())));
            }
        }
        public async Task<bool> SelectphotoAsync()
        {
            int nErrores = 0;
            try
            {
                Foto = await ControllerPhoto.Instancia.SelectphotoAsync_();
                if (Foto != null)
                {
                    RutaFoto = Foto.Path;
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                nErrores++;
            }
            return (nErrores == 0);
        }

        public Command m_tomarFotoComand;

        public Command TomarFotoComand
        {
            get
            {
                return (m_tomarFotoComand ?? (m_tomarFotoComand = new Command(async () => await TakePhoto())));
            }
        }

        public async Task<bool> TakePhoto()
        {
            int nErrores = 0;
            try
            {
                Foto = await ControllerPhoto.Instancia.ScreenphotoAsync();
                if (Foto != null)
                {
                    RutaFoto = Foto.Path;
                }

            }
            catch (Exception ex)
            {
                string error = ex.ToString();
                
                nErrores++;
            }
            return (nErrores == 0);
        }

        

    }
}
