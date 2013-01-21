using Android.App;
using Android.OS;
using Android.Widget;
using MonoDroid.Attributes;

namespace MonoDroid.Activities {

	[Sample(Label = "Popup Menu")]
	public class PopupMenuFragment : Android.Support.V4.App.Fragment {

		public override void OnCreate(Bundle p0) {
			base.OnCreate(p0);
		}

		public override Android.Views.View OnCreateView(Android.Views.LayoutInflater inflater, Android.Views.ViewGroup container, Bundle savedInstanceState) {
			var view = inflater.Inflate(Resource.Layout.fragment_popup_menu, container, false);
			var btn = view.FindViewById<Button>(Resource.Id.fragment_popup_menu_button);
			btn.Click += delegate {
				var menu = new PopupMenu(this.Activity, btn);
				menu.Inflate(Resource.Menu.fragment_popup_menu_popup);
				
				menu.MenuItemClick += (sender, e) => {
					Toast.MakeText(this.Activity, string.Format("{0} selected", e.Item.TitleFormatted), ToastLength.Short).Show();
				};
				
				menu.DismissEvent += (sender, e) => {
					Toast.MakeText(this.Activity, "menu dismissed", ToastLength.Short).Show();
				};
				
				menu.Show();
			};
			return view;
		}

		public override void OnPause() {
			base.OnPause();
		}
	}
}

