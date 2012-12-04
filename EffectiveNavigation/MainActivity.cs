using Android.App;
using Android.OS;
using Android.Support.V4.App;
using Android.Support.V4.View;

namespace EffectiveNavigation {

	[Activity (Label = "@string/AppName", Icon = "@drawable/ic_launcher", MainLauncher = true)]
	public class MainActivity : FragmentActivity {

		/// <summary>
		/// The {@link android.support.v4.view.PagerAdapter} that will provide fragments for each of the
		/// three primary sections of the app. We use a {@link android.support.v4.app.FragmentPagerAdapter}
		/// derivative, which will keep every loaded fragment in memory. If this becomes too memory
		/// intensive, it may be best to switch to a {@link android.support.v4.app.FragmentStatePagerAdapter}.
		/// </summary>
		AppSectionsPagerAdapter mAppSectionsPagerAdapter;

		/// <summary>
		/// The {@link ViewPager} that will display the three primary sections of the app, one at a
		/// time.
		/// </summary>
		ViewPager mViewPager;

		protected override void OnCreate(Bundle bundle) {
			base.OnCreate(bundle);

			this.SetContentView(Resource.Layout.MainActivity);

			// Create the adapter that will return a fragment for each of the three primary sections
			// of the app.
			this.mAppSectionsPagerAdapter = new AppSectionsPagerAdapter(this.SupportFragmentManager);
			// Set up the action bar.
			var actionBar = this.ActionBar;
			// Specify that the Home/Up button should not be enabled, since there is no hierarchical
			// parent.
			actionBar.SetHomeButtonEnabled(false);
			// Specify that we will be displaying tabs in the action bar.
			actionBar.NavigationMode = ActionBarNavigationMode.Tabs;
			// Set up the ViewPager, attaching the adapter and setting up a listener for when the
			// user swipes between sections.
			this.mViewPager = this.FindViewById<ViewPager>(Resource.Id.Pager);
			this.mViewPager.Adapter = this.mAppSectionsPagerAdapter;
			// When swiping between different app sections, select the corresponding tab.
			// We can also use ActionBar.Tab#select() to do this if we have a reference to the
			// Tab.
			this.mViewPager.PageSelected += delegate(object sender, ViewPager.PageSelectedEventArgs e) {
				actionBar.SetSelectedNavigationItem(e.P0);
			};

			// For each of the sections in the app, add a tab to the action bar.
			for (var i = 0; i < this.mAppSectionsPagerAdapter.Count; i++) {
				var tab = actionBar.NewTab().SetText(this.mAppSectionsPagerAdapter.GetPageTitle(i));
				tab.TabSelected += delegate(object sender, Android.App.ActionBar.TabEventArgs e) {
					this.mViewPager.CurrentItem = tab.Position;
				};
				actionBar.AddTab(tab);
			}
		}
	}
}


