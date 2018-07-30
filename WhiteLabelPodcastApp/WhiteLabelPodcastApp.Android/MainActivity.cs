
using Android.App;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Support.Design.Widget;
using Android.Support.V4.Widget;
using Android.Support.V7.App;
using Android.Graphics.Drawables;
using Android.Graphics;

namespace WhiteLabelPodcastApp.Droid
{
	[Activity (Label = "WhiteLabelPodcastApp.Android", MainLauncher = true, Icon = "@drawable/icon" , Theme = "@style/MyCustomTheme")]
	public class MainActivity : AppCompatActivity
    {
        DrawerLayout drawerLayout;
        NavigationView navigationView;
        FrameLayout fragmentHolder;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            var toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);
            Android.Support.V7.App.ActionBar actionbar = SupportActionBar;
            actionbar.SetDisplayHomeAsUpEnabled(true);

            Drawable drawable = Resources.GetDrawable(Resource.Drawable.hamburger_icon);
            Bitmap bitmap = ((BitmapDrawable)drawable).Bitmap;
            Drawable newdrawable = new BitmapDrawable(Resources, Bitmap.CreateScaledBitmap(bitmap, 60, 60, true));
            actionbar.SetHomeAsUpIndicator(newdrawable);
            actionbar.Title = "Dashboard";

            drawerLayout = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            navigationView = FindViewById<NavigationView>(Resource.Id.nav_view);
            fragmentHolder = FindViewById<FrameLayout>(Resource.Id.frag_holder);

            navigationView.NavigationItemSelected += (sender, e) => {
                e.MenuItem.SetChecked(true);
                //react to click here and swap fragments or navigate
                drawerLayout.CloseDrawers();
            };

            //SupportFragmentManager.PutFragment
            setFragment(new Dashboard.DashboardFragment());

        }

        void setFragment(  Android.Support.V4.App.Fragment frag)
        {
            Android.Support.V4.App.FragmentTransaction fragmentTx = this.SupportFragmentManager.BeginTransaction();
            fragmentTx.Replace(Resource.Id.frag_holder, frag);
            fragmentTx.Commit();
        }
        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Android.Resource.Id.Home:
                    drawerLayout.OpenDrawer(Android.Support.V4.View.GravityCompat.Start);
                    return true;
            }
            return base.OnOptionsItemSelected(item);
        }
    }
}


