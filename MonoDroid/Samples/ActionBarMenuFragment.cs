using Android.App;
using Android.OS;
using MonoDroid.Attributes;
using Android.Views;
using Android.Widget;

namespace MonoDroid.Samples {

	[Sample(Label = "ActionBar Menu")]
	public class ActionBarMenuFragment : Android.Support.V4.App.Fragment {

		public override void OnCreate(Bundle savedInstanceState) {
			base.OnCreate(savedInstanceState);
			this.SetHasOptionsMenu(true);
		}

		public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) {
			var view = inflater.Inflate(Resource.Layout.activity_actionbarmenu, container, false);
			return view;
		}

		public override void OnCreateOptionsMenu(IMenu menu, MenuInflater inflater) {
			base.OnCreateOptionsMenu(menu, inflater);
			inflater.Inflate(Resource.Menu.activity_actionbarmenu_menu, menu);
		}

		public override bool OnOptionsItemSelected(IMenuItem item) {
			var msg = string.Format("Option item {0} selected", item.TitleFormatted);
			Toast.MakeText(this.Activity, msg, ToastLength.Short).Show();
			this.View.FindViewById<TextView>(Resource.Id.activity_actionbarmenu_textview).Text = msg;

			return base.OnOptionsItemSelected(item);
		}
	}
}

