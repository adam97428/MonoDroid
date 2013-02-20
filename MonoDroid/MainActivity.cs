using System;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Views;
using Android.Widget;
using Android.OS;
using MonoDroid.Attributes;
using MonoDroid.Fragments;

namespace MonoDroid {

	[Activity (Label = "@string/app_name", MainLauncher = true)]
	public class MainActivity : Android.Support.V4.App.FragmentActivity {

		private MenuFragment _menuFrag;

		public static MainActivity Current {
			get;
			private set;
		}

		protected override void OnCreate(Bundle bundle) {
			base.OnCreate(bundle);
			//this.Window.SetFlags(WindowManagerFlags.Fullscreen, WindowManagerFlags.Fullscreen);
			//this.Window.RequestFeature(WindowFeatures.NoTitle);

			Current = this;

			this.SetContentView(Resource.Layout.activity_main);

			this._menuFrag = new MenuFragment();
			var fm = this.SupportFragmentManager;
			var trans = fm.BeginTransaction();
			trans.Replace(Resource.Id.activity_main_menu_frame_layout, this._menuFrag, "Test");
			//trans.AddToBackStack("Test");
			trans.Commit();
		}

		public void PushFragment(Android.Support.V4.App.Fragment frag) {
			var fm = this.SupportFragmentManager;
			var trans = fm.BeginTransaction();
			var contentFrameLayout = this.FindViewById(Resource.Id.activity_main_content_frame_layout);
			if (contentFrameLayout != null ) {
				trans.Replace(Resource.Id.activity_main_content_frame_layout, frag);
			}
			else {
				trans.Replace(Resource.Id.activity_main_menu_frame_layout, frag);
			}
			trans.AddToBackStack(null);
			trans.Commit();
		}

		public void ShowSample(Sample sample) {
			var fragmentType = typeof(Android.Support.V4.App.Fragment);
			if (fragmentType.IsAssignableFrom(sample.Launch)) {
				var frag = Activator.CreateInstance(sample.Launch) as Android.Support.V4.App.Fragment;
				this.PushFragment(frag);
				this.Title = sample.Label;
			}
			else {
				var intent = new Intent(this, sample.Launch);
				this.StartActivity(intent);
			}
		}

		protected override void OnResume() {
			if (this.RequestedOrientation != AndroidApp.CurrentApp.ScreenOrientation) {
				this.RequestedOrientation = AndroidApp.CurrentApp.ScreenOrientation;
			}
			base.OnResume();
		}
	}
}


