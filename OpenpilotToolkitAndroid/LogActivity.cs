using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Toolbar = AndroidX.AppCompat.Widget.Toolbar;
using AndroidX.AppCompat.App;
using AndroidX.Core.View;
using AndroidX.DrawerLayout.Widget;
using Google.Android.Material.Navigation;
using Octokit;
using System.IO;
using System.Linq;
using Xamarin.Essentials;
using Android.Widget;

namespace OpenpilotToolkitAndroid
{
    [Activity(Label = "Logs", Theme = "@style/AppTheme.NoActionBar")]
    public class LogActivity : AppCompatActivity, NavigationView.IOnNavigationItemSelectedListener
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            AppCompatDelegate.DefaultNightMode = AppCompatDelegate.ModeNightYes;

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);

            SetContentView(Resource.Layout.activity_log);

            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);

            var drawer = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            var toggle = new ActionBarDrawerToggle(this, drawer, toolbar, Resource.String.navigation_drawer_open,
                Resource.String.navigation_drawer_close);
            drawer.AddDrawerListener(toggle);
            toggle.SyncState();

            NavigationView navigationView = FindViewById<NavigationView>(Resource.Id.nav_view);
            navigationView.SetNavigationItemSelectedListener(this);

            var tietLog = (TextView)FindViewById(Resource.Id.tietLog);
            
            var directoryInfo = new DirectoryInfo(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal));
            var logFile = directoryInfo.GetFiles("*.txt", SearchOption.TopDirectoryOnly)
                .OrderByDescending(file => file.LastWriteTime).FirstOrDefault();
            if (logFile != null)
            {
                
                using (var fileStream = new System.IO.FileStream(logFile.FullName, System.IO.FileMode.Open, FileAccess.Read,FileShare.ReadWrite))
                using (var streamReader = new StreamReader(fileStream))
                {
                    tietLog.Text = streamReader.ReadToEnd();
                }

            }
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions,
                    [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        public bool OnNavigationItemSelected(IMenuItem item)
        {
            int id = item.ItemId;

            if (id == Resource.Id.log_file)
            {

            }
            else if (id == Resource.Id.fork_installer)
            {
                Intent mainActivity = new Intent(this, typeof(MainActivity));
                StartActivity(mainActivity);
                OverridePendingTransition(Android.Resource.Animation.SlideInLeft, Android.Resource.Animation.FadeOut);
                Finish();

            }
            else if (id == Resource.Id.ssh_wizard)
            {
                Intent sshActivity = new Intent(this, typeof(SshActivity));
                StartActivity(sshActivity);
                OverridePendingTransition(Android.Resource.Animation.SlideInLeft, Android.Resource.Animation.FadeOut);
                Finish();

            }


            DrawerLayout drawer = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            drawer.CloseDrawer(GravityCompat.Start);
            return true;
        }
    }
}