using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using MonoDroid.Attributes;
using MonoDroid.Fragments;

namespace MonoDroid {

	[Activity (Label = "@string/app_name", MainLauncher = true)]
	public class MainActivity : Android.Support.V4.App.FragmentActivity, ListView.IOnItemClickListener {

		private MenuFragment _menuFrag;

		protected override void OnCreate(Bundle bundle) {
			base.OnCreate(bundle);

			this.SetContentView(Resource.Layout.activity_main);

			this._menuFrag = new MenuFragment();
			var fm = this.SupportFragmentManager;
			var trans = fm.BeginTransaction();
			trans.Replace(Resource.Id.activity_main_menu_frame_layout, this._menuFrag, "Test");
			trans.AddToBackStack("Test");
			trans.Commit();
		}

		public void OnItemClick(AdapterView parent, View view, int position, long id) {
			var sample = view.Tag as Sample;
			if (sample != null) {
				var intent = new Intent(this, sample.Launch);
				this.StartActivity(intent);
			}
			else {
				Toast.MakeText(this, "Error: Sample is empty!", ToastLength.Short);
			}
		}

	}
}


