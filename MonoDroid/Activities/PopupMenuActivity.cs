using Android.App;
using Android.OS;
using Android.Widget;
using MonoDroid.Attributes;

namespace MonoDroid.Activities {

	[Sample]
	[Activity (Label = "Popup Menu")]
	public class PopupMenuActivity : Activity {

		protected override void OnCreate(Bundle bundle) {
			base.OnCreate(bundle);

			// Create your application here
			this.SetContentView(Resource.Layout.activity_popup_menu);

			var btn = this.FindViewById<Button>(Resource.Id.activity_popup_menu_button);
			btn.Click += delegate {
				var menu = new PopupMenu(this, btn);
				menu.Inflate(Resource.Menu.activity_popup_menu_popup);

				menu.MenuItemClick += (sender, e) => {
					Toast.MakeText(this, string.Format("{0} selected", e.Item.TitleFormatted), ToastLength.Short).Show();
				};
				
				menu.DismissEvent += (sender, e) => {
					Toast.MakeText(this, "menu dismissed", ToastLength.Short).Show();
				};
				
				menu.Show();
			};
		}
	}
}

