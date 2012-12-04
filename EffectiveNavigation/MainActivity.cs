using Android.App;
using Android.OS;

namespace EffectiveNavigation {

	[Activity (Label = "EffectiveNavigation", MainLauncher = true)]
	public class MainActivity : Activity {

		protected override void OnCreate(Bundle bundle) {
			base.OnCreate(bundle);

			SetContentView(Resource.Layout.MainActivity);
		}
	}
}


