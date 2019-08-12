using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Plugin.Permissions;
using Android.Support.V4.App;
using Android;

namespace EPickingService.Droid
{
    [Activity(Label = "EPickingService", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = false, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;
            GetPermissions();
            base.OnCreate(savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App());
           
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, Permission[] grantResults)
        {
            PermissionsImplementation.Current.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }


        #region Permisos de la app
        private void GetPermissions()
        {
            try
            {
                ActivityCompat.RequestPermissions(this, new string[]
                    {

                     Manifest.Permission.Camera,
                     Manifest.Permission.AccessFineLocation,
                      Manifest.Permission.ReadExternalStorage,
                       Manifest.Permission.WriteExternalStorage,
                    }, 0);
            }
            catch (Exception ex)
            {
                throw;

            }
        }
        #endregion Fin de los permisos
    }
}