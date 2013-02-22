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

		private int _menuFrameLayoutId;
		private int _contentFrameLayoutId;

		public static MainActivity Current {
			get;
			private set;
		}

		protected override void OnCreate(Bundle bundle) {
			base.OnCreate(bundle);
			//this.Window.SetFlags(WindowManagerFlags.Fullscreen, WindowManagerFlags.Fullscreen);
			//this.Window.RequestFeature(WindowFeatures.NoTitle);

			Current = this;

			this.SetContentView();

			this._menuFrag = new MenuFragment();
			var fm = this.SupportFragmentManager;
			var trans = fm.BeginTransaction();
			trans.Replace(this._menuFrameLayoutId, this._menuFrag, "Test");
			//trans.AddToBackStack("Test");
			trans.Commit();
		}

		private void SetContentView() {
			var matchParent = ViewGroup.LayoutParams.MatchParent;
			var rootLinearLayout = new LinearLayout(this) {
				LayoutParameters = new ViewGroup.LayoutParams(matchParent, matchParent),
				Orientation = Orientation.Horizontal
			};
			// add menu fragment
			var menuFrameLayout = new FrameLayout(this) {
				Id = AndroidApp.CurrentApp.GenerateViewId(),
				LayoutParameters = new LinearLayout.LayoutParams(0, matchParent, 1f)
			};
			rootLinearLayout.AddView(menuFrameLayout);
			this._menuFrameLayoutId = menuFrameLayout.Id;
			// if is large screen, add content frame layout
			if (AndroidApp.CurrentApp.IsLargeScreen()) {
				var contentFrameLayout = new FrameLayout(this) {
					Id = AndroidApp.CurrentApp.GenerateViewId(),
					LayoutParameters = new LinearLayout.LayoutParams(0, matchParent, 3f)
				};
				contentFrameLayout.SetBackgroundColor(new Android.Graphics.Color(0x33, 0x33, 0x33, 0xff));
				rootLinearLayout.AddView(contentFrameLayout);
				this._contentFrameLayoutId = contentFrameLayout.Id;
			}

			this.SetContentView(rootLinearLayout);
		}

		public void PushFragment(Android.Support.V4.App.Fragment frag) {
			var fm = this.SupportFragmentManager;
			var trans = fm.BeginTransaction();
			var contentFrameLayout = this.FindViewById(this._contentFrameLayoutId);
			if (contentFrameLayout != null ) {
				trans.Replace(this._contentFrameLayoutId, frag);
			}
			else {
				trans.Replace(this._menuFrameLayoutId, frag);
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


