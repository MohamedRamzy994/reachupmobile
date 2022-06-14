using Android.App;
using Android.Content;
using Android.Net;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using Java.Net;

namespace ReachUpMobileApp
{
    [Activity(Label = "@string/app_name",  Theme = "@style/AppTheme")]
    public class MainActivity : AppCompatActivity, BottomNavigationView.IOnNavigationItemSelectedListener
    {
       

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            BottomNavigationView navigation = FindViewById<BottomNavigationView>(Resource.Id.navigation);
            navigation.SelectedItemId = Resource.Id.navigation_home;
            navigation.SetOnNavigationItemSelectedListener(this);
            SupportActionBar.SetDisplayShowHomeEnabled(true);
            SupportActionBar.SetDisplayUseLogoEnabled(true);
            SupportActionBar.SetLogo(Resource.Mipmap.ic_launcher);
            
             Button btnstart = FindViewById<Button>(Resource.Id.btnstart);
            Button btnfeatures = FindViewById<Button>(Resource.Id.btnfeatures);
            TextView textView = FindViewById<TextView>(Resource.Id.textView12);
             ImageButton btninstagram = FindViewById<ImageButton>(Resource.Id.imageButton1);
            ImageButton btnfb = FindViewById<ImageButton>(Resource.Id.imageButton3);
            ImageButton btntwitter = FindViewById<ImageButton>(Resource.Id.imageButton4);
            ImageButton btnwhtsapp = FindViewById<ImageButton>(Resource.Id.imageButton2);
            textView.Click += TextView_Click;
            btnstart.Click += Btnstart_Click;
            btnfeatures.Click += Btnfeatures_Click;
            btninstagram.Click += Btninstagram_Click;
            btnfb.Click += Btnfb_Click;
            btnwhtsapp.Click += Btnwhtsapp_Click;
            btntwitter.Click += Btntwitter_Click;






        }

        private void Btntwitter_Click(object sender, System.EventArgs e)
        {

            Intent intent = new Intent(Intent.ActionView, Uri.Parse("https://twitter.com/"));
           
            StartActivity(intent);
        }

        private void Btnwhtsapp_Click(object sender, System.EventArgs e)
        {

            Intent intent = new Intent(Intent.ActionView, Uri.Parse("https://api.whatsapp.com/send?phone="+ +201013315001+"&text="+URLEncoder.Encode("Hello From ReachUp","UTF-8")));
            intent.SetPackage("com.whatsapp");
            StartActivity(intent);
        }

        private void Btnfb_Click(object sender, System.EventArgs e)
        {
            Intent intent = new Intent(Intent.ActionView,Uri.Parse("fb://profile/myprofile"));
            
            StartActivity(intent);
        }

        private void Btninstagram_Click(object sender, System.EventArgs e)
        {
            
            Intent intent= this.PackageManager.GetLaunchIntentForPackage("com.instagram.android");
            StartActivity(intent);
        }

        private void TextView_Click(object sender, System.EventArgs e)
        {
            Intent intent = new Intent(Intent.ActionView, Uri.Parse("http://www.reachupweb.com"));
            StartActivity(intent);
        }

        private void Btnfeatures_Click(object sender, System.EventArgs e)
        {
            Intent services = new Intent(this, typeof(ServicesActivity));
            StartActivity(services);
        }

        private void Btnstart_Click(object sender, System.EventArgs e)
        {
            Intent services = new Intent(this,typeof(ServicesActivity));
            StartActivity(services);
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
        public bool OnNavigationItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.Id.navigation_home:
                    Intent home = new Intent(this, typeof(MainActivity));
                    this.StartActivity(home);
                    return true;
                case Resource.Id.navigation_dashboard:
                    Intent services = new Intent(this, typeof(ServicesActivity));
                    this.StartActivity(services);
                    return true;
                case Resource.Id.navigation_notifications:
                    Intent contactus = new Intent(this, typeof(ContactActivity));
                    this.StartActivity(contactus);
                    return true;
                case Resource.Id.googlemap:
                    Uri gmmIntentUri = Uri.Parse("google.streetview:cbll=46.414382,10.013988");

                    Intent mapintent = new Intent(Intent.ActionView,gmmIntentUri);
                    mapintent.SetPackage("com.google.android.apps.maps");
                    this.StartActivity(mapintent);
                    return true;
            }
            return false;
        }
    }
}

