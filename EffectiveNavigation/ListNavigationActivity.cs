using Android.App;
using Android.OS;
using Android.Support.V4.App;
using Android.Support.V4.View;
using Android.Widget;
using Android.Content;

namespace EffectiveNavigation {

	[Activity (Label = "")]
	public class ListNavigationActivity : FragmentActivity, ActionBar.IOnNavigationListener {

		/// <summary>
		/// The {@link android.support.v4.view.PagerAdapter} that will provide fragments for each of the
		/// three primary sections of the app. We use a {@link android.support.v4.app.FragmentPagerAdapter}
		/// derivative, which will keep every loaded fragment in memory. If this becomes too memory
		/// intensive, it may be best to switch to a {@link android.support.v4.app.FragmentStatePagerAdapter}.
		/// </summary>
		ListNavSectionsPagerAdapter _navSectionsPagerAdapter;
		
		/// <summary>
		/// The {@link ViewPager} that will display the three primary sections of the app, one at a
		/// time.
		/// </summary>
		ViewPager _viewPager;
		
		protected override void OnCreate(Bundle bundle) {
			base.OnCreate(bundle);
			
			this.SetContentView(Resource.Layout.MainActivity);
			
			// Create the adapter that will return a fragment for each of the three primary sections
			// of the app.
			this._navSectionsPagerAdapter = new ListNavSectionsPagerAdapter(this.SupportFragmentManager);
			// Set up the action bar.
			var actionBar = this.ActionBar;
			// Specify that the Home button should show an "Up" caret, indicating that touching the
			// button will take the user one step up in the application's hierarchy.
			actionBar.SetDisplayHomeAsUpEnabled(true);
			// Specify that we will be displaying list in the action bar.
			actionBar.NavigationMode = ActionBarNavigationMode.List;
			
			var titles = new string[this._navSectionsPagerAdapter.Count];
			for (var i = 0; i < titles.Length; i++) {
				titles[i] = this._navSectionsPagerAdapter.GetPageTitle(i);
			}
			
			actionBar.SetListNavigationCallbacks(
				new ArrayAdapter(
					actionBar.ThemedContext,
					Resource.Layout.ListNavigationActivityActionbarListItem,
					Android.Resource.Id.Text1,
					titles
				),
				this
			);
			// Set up the ViewPager, attaching the adapter and setting up a listener for when the
			// user swipes between sections.
			this._viewPager = this.FindViewById<ViewPager>(Resource.Id.Pager);
			this._viewPager.Adapter = this._navSectionsPagerAdapter;
			// When swiping between different app sections, select the corresponding tab.
			// We can also use ActionBar.Tab#select() to do this if we have a reference to the
			// Tab.
			this._viewPager.PageSelected += delegate(object sender, ViewPager.PageSelectedEventArgs e) {
				actionBar.SetSelectedNavigationItem(e.P0);
			};
		}
		
		public bool OnNavigationItemSelected(int itemPosition, long itemId) {
			this._viewPager.CurrentItem = itemPosition;
			return true;
		}

		public override bool OnOptionsItemSelected(Android.Views.IMenuItem item) {
			if (item.ItemId == Android.Resource.Id.Home) {
				// This is called when the Home (Up) button is pressed in the action bar.
				// Create a simple intent that starts the hierarchical parent activity and
				// use NavUtils in the Support Package to ensure proper handling of Up.
				var upIntent = new Intent(this, typeof(MainActivity));
				if (NavUtils.ShouldUpRecreateTask(this, upIntent)) {
					// This activity is not part of the application's task, so create a new task
					// with a synthesized back stack.
					TaskStackBuilder.Create(this)
					// If there are ancestor activities, they should be added here.
						.AddNextIntent(upIntent)
							.StartActivities();
					this.Finish();
				}
				else {
					// This activity is part of the application's task, so simply
					// navigate up to the hierarchical parent activity.
					NavUtils.NavigateUpTo(this, upIntent);
				}
				return true;
			}
			return base.OnOptionsItemSelected(item);
		}
		
	}
}


