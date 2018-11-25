using System;
using System.IO;
using Android.App;
using Android.Content.PM;
using Android.OS;
using lcpi.data.oledb;
//using ClubItSSC.Droid;

namespace ClubItSSC
{
    [Activity(Label = "ClubIt", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        //readonly String Name;
        //readonly String Password;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            //TabLayoutResource = Resource.Layout.Tabbar;
            //ToolbarResource = Resource.Layout.Toolbar;
            base.OnCreate(savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);

            string conn = "@provider= Microsoft.Jet.OLEDB.4.0; data source=\\Users\\micae\\Source\\Repos\\ClubItSSC\\ClubItDatabase.mdb";
            string DbFolderPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            string FullPath = Path.Combine(DbFolderPath, conn);

            //OleDbConnection conn = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0; Data Source=C:\Users\micae\Source\Repos\ClubItSSC\ClubItDatabase.mdb");
            LoadApplication(new App(FullPath));
        }
    }
}