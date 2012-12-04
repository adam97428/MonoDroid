using Android.App;
using Android.OS;

namespace EffectiveNavigation {

	[Activity (Label = "@string/AppName", Icon = "@drawable/ic_launcher", MainLauncher = true)]
	public class MainActivity : Activity {

		AppSectionsPagerAdapter mAppSectionsPagerAdapter;

		protected override void OnCreate(Bundle bundle) {
			base.OnCreate(bundle);

			SetContentView(Resource.Layout.MainActivity);
		}
	}
}


