using Android.App;
using Android.OS;
using Android.Support.V4.App;
using Android.Support.V4.View;
using Android.Views;
using Android.Content;

namespace EffectiveNavigation {

	[Activity (Label = "@string/DemoCollection")]
	public class CollectionDemoActivity : FragmentActivity {

		/// <summary>
		/// The {@link android.support.v4.view.PagerAdapter} that will provide fragments representing
		/// each object in a collection. We use a {@link android.support.v4.app.FragmentStatePagerAdapter}
		/// derivative, which will destroy and re-create fragments as needed, saving and restoring their
		/// state in the process. This is important to conserve memory and is a best practice when
		/// allowing navigation between objects in a potentially large collection.
		/// </summary>
		private DemoCollectionPagerAdapter mDemoCollectionPagerAdapter;

		/// <summary>
		/// The {@link android.support.v4.view.ViewPager} that will display the object collection.
		/// </summary>
		private ViewPager mViewPager;

		protected override void OnCreate(Bundle bundle) {
			base.OnCreate(bundle);
			this.SetContentView(Resource.Layout.CollectionDemoActivity);

			// Create an adapter that when requested, will return a fragment representing an object in
			// the collection.
			// 
			// ViewPager and its adapters use support library fragments, so we must use
			// getSupportFragmentManager.
			this.mDemoCollectionPagerAdapter = new DemoCollectionPagerAdapter(this.SupportFragmentManager);

			// Set up action bar.
			var actionBar = this.ActionBar;
			// Specify that the Home button should show an "Up" caret, indicating that touching the
			// button will take the user one step up in the application's hierarchy.
			actionBar.SetDisplayHomeAsUpEnabled(true);

			// Set up the ViewPager, attaching the adapter.
			this.mViewPager = this.FindViewById<ViewPager>(Resource.Id.Pager);
			this.mViewPager.Adapter = this.mDemoCollectionPagerAdapter;
		}

		public override bool OnOptionsItemSelected(IMenuItem item) {
			switch (item.ItemId) {
			case Android.Resource.Id.Home:
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

