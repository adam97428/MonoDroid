using Android.App;
using Android.OS;
using MonoDroid.Attributes;
using Android.Views;
using Android.Widget;

namespace MonoDroid.Activities {

	[Sample]
	[Activity (Label = "ActionBar Menu")]
	public class ActionBarMenuActivity : Activity {

		protected override void OnCreate(Bundle bundle) {
			base.OnCreate(bundle);

			// Create your application here
			this.SetContentView(Resource.Layout.activity_actionbarmenu);
		}

		public override bool OnCreateOptionsMenu(IMenu menu) {
			this.MenuInflater.Inflate(Resource.Menu.activity_actionbarmenu_menu, menu);
			return true;
		}

		public override bool OnOptionsItemSelected(IMenuItem item) {
			var msg = string.Format("Option item {0} selected", item.TitleFormatted);
			Toast.MakeText(this, msg, ToastLength.Short).Show();
			this.FindViewById<TextView>(Resource.Id.activity_actionbarmenu_textview).Text = msg;

			return base.OnOptionsItemSelected(item);
		}
	}
}

