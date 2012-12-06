using Android.OS;
using Android.Views;
using Android.Widget;
using Android.Content;
using Android.Support.V4.App;

namespace EffectiveNavigation {

	/// <summary>
	/// A fragment that launches other parts of the demo application.
	/// </summary>
	public class LaunchpadSectionFragment : Fragment {

		public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) {
			var rootView = inflater.Inflate(Resource.Layout.FragmentSectionLaunchpad, container, false);

			var demoCollectionBtn = rootView.FindViewById<Button>(Resource.Id.DemoCollectionButton);
			// Demonstration of a collection-browsing activity.
			demoCollectionBtn.Click += delegate {
				var intent = new Intent(this.Activity, typeof(CollectionDemoActivity));
				this.StartActivity(intent);
			};

			var externalActivityBtn = rootView.FindViewById<Button>(Resource.Id.DemoExternalActivityButton);
			// Demonstration of navigating to external activities.
			externalActivityBtn.Click += delegate {
				// Create an intent that asks the user to pick a photo, but using
				// FLAG_ACTIVITY_CLEAR_WHEN_TASK_RESET, ensures that relaunching
				// the application from the device home screen does not return
				// to the external activity.
				var externalActivityIntent = new Intent(Intent.ActionPick);
				externalActivityIntent.SetType("image/*");
				externalActivityIntent.AddFlags(ActivityFlags.ClearWhenTaskReset);
				this.StartActivity(externalActivityIntent);
			};
			return rootView;
		}

	}
}

