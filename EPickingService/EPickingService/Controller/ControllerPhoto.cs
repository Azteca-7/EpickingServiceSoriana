using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EPickingService.Controller
{
  public class ControllerPhoto
    {
        public ControllerPhoto()
        {
            CrossMedia.Current.Initialize();
        }
        private static ControllerPhoto m_Instancia;

        public static ControllerPhoto Instancia
        {
            get
            {
                if (m_Instancia == null)
                {
                    m_Instancia = new ControllerPhoto();
                }

                return m_Instancia;
            }
        }
        public async Task<MediaFile> SelectphotoAsync_()
        {
            MediaFile foto = null;
            try
            {

                if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
                {
                    return null;
                }
                else
                {
                    foto = await CrossMedia.Current.PickPhotoAsync();
                }

            }
            catch (TaskCanceledException)
            {
                foto = null;
            }
            return foto;
        }

        public async Task<MediaFile> ScreenphotoAsync()
        {
            MediaFile foto = null;
            try
            {
                if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
                {
                    return null;
                }
                else
                {
                    foto = await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions());
                }

            }
            catch (TaskCanceledException)
            {
                foto = null;
            }
            return foto;
        }

    }
}
