using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

using Android.Support.V4.App;
using Android.Support.V4.View;
using Android.Support.V4.Widget;

using Android.Views.Animations;
using Android.Animation;

namespace MonoDroid.Samples {

	[MonoDroid.Attributes.Sample(Label = "Android Animations")]
	public class AnimationsFragment : Android.Support.V4.App.Fragment {

		private ViewPager _viewPager;
		private FragmentPagerAdapter _pagerAdapter;

		private IList<ActionBar.Tab> _tabs;
		private ActionBarNavigationMode _navMode;

		public override void OnCreate(Bundle savedInstanceState) {
			base.OnCreate(savedInstanceState);
			this._pagerAdapter = new AnimationsFragmetPagerAdapter(this.Activity.SupportFragmentManager);
		}

		public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) {
			var view = inflater.Inflate(Resource.Layout.fragment_animations, container, false);
			this._viewPager = view.FindViewById<ViewPager>(Resource.Id.fragment_animations_viewpager);
			this._viewPager.Adapter = this._pagerAdapter;
			this._viewPager.PageSelected += (object sender, ViewPager.PageSelectedEventArgs e) => {
				var actionBar = this.Activity.ActionBar;
				if (actionBar.SelectedNavigationIndex != e.P0) {
					actionBar.SetSelectedNavigationItem(e.P0);
				}
			};
			return view;
		}

		public override void OnStart() {
			base.OnStart();
			var actionBar = this.Activity.ActionBar;
			this._navMode = actionBar.NavigationMode;
			actionBar.NavigationMode = ActionBarNavigationMode.Tabs;
			this._tabs = new List<ActionBar.Tab>();
			var viewAnimTab = actionBar.NewTab().SetText(this._pagerAdapter.GetPageTitleFormatted(0));
			viewAnimTab.TabSelected += OnTabSelected;
			actionBar.AddTab(viewAnimTab);
			this._tabs.Add(viewAnimTab);

			var propAnimTab = actionBar.NewTab().SetText(this._pagerAdapter.GetPageTitleFormatted(1));
			propAnimTab.TabSelected += OnTabSelected;
			actionBar.AddTab(propAnimTab);
			this._tabs.Add(propAnimTab);

			var layoutAnimTab = actionBar.NewTab().SetText(this._pagerAdapter.GetPageTitleFormatted(2));
			layoutAnimTab.TabSelected += OnTabSelected;
			actionBar.AddTab(layoutAnimTab);
			this._tabs.Add(layoutAnimTab);
		}

		void OnTabSelected(object sender, ActionBar.TabEventArgs e) {
			var tab = (ActionBar.Tab)sender;
			if (this._viewPager.CurrentItem != tab.Position) {
				this._viewPager.CurrentItem = tab.Position;
			}
		}

		public override void OnStop() {
			var actionBar = this.Activity.ActionBar;
			foreach (var tab in this._tabs) {
				tab.TabSelected -= OnTabSelected;
				actionBar.RemoveTab(tab);
				tab.Dispose();
			}
			this._tabs.Clear();
			actionBar.NavigationMode = this._navMode;
			base.OnStop();
		}
	}

	public class AnimationsFragmetPagerAdapter : FragmentPagerAdapter {

		public AnimationsFragmetPagerAdapter(Android.Support.V4.App.FragmentManager fm) : base(fm) {
		}

		public override Android.Support.V4.App.Fragment GetItem(int position) {
			if (position == 0) {
				return new ViewAnimationFragment();
			}
			if (position == 1) {
				return new PropertyAnimationFragment();
			}
			return new LayoutAnimationFragment();
		}

		public override int Count {
			get {
				return 3;
			}
		}

		public override Java.Lang.ICharSequence GetPageTitleFormatted(int position) {
			string title;
			if (position == 0) {
				title = "VIEW";
			}
			else if (position == 1) {
				title = "PROPERTY";
			}
			else {
				title = "LAYOUT";
			}
			return new Java.Lang.String(title);
		}

	}

	public class ViewAnimationFragment : Android.Support.V4.App.Fragment {

		private ImageView _imageView;
		private Button _button;
		private int _imageViewResource;

		public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) {
			var view = inflater.Inflate(Resource.Layout.fragment_animations_view_animation, container, false);

			this._imageView = view.FindViewById<ImageView>(Resource.Id.fragment_animations_view_animation_imageView);

			SetImageResource(Resource.Drawable.image1);

			this._button = view.FindViewById<Button>(Resource.Id.fragment_animations_view_animation_button);

			this._button.Click += (object sender, EventArgs e) => this.SwitchImage();

			return view;
		}

		void SetImageResource(int imageSource) {
			this._imageView.SetImageResource(imageSource);
			this._imageViewResource = imageSource;
		}

		private void SwitchImage() {
			var fadeOutAnim = new AlphaAnimation(1.0f, 0.0f);
			fadeOutAnim.Duration = 500;
			//fadeOutAnim.SetAnimationListener(new Android.Views.Animations.in
			fadeOutAnim.AnimationEnd += (object sender, Animation.AnimationEndEventArgs e) => {
				if (this._imageViewResource == Resource.Drawable.image1) {
					this.SetImageResource(Resource.Drawable.image2);
				}
				else {
					this.SetImageResource(Resource.Drawable.image1);
				}
				// fade in
				var fadeIn = new AlphaAnimation(0.0f, 1.0f);
				fadeIn.Duration = 500;
				this._imageView.StartAnimation(fadeIn);
			};
			this._imageView.StartAnimation(fadeOutAnim);
		}
	}

	public class PropertyAnimationFragment : Android.Support.V4.App.Fragment {

		public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) {
			return base.OnCreateView(inflater, container, savedInstanceState);
		}
	}

	public class LayoutAnimationFragment : Android.Support.V4.App.Fragment {

		public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) {
			return base.OnCreateView(inflater, container, savedInstanceState);
		}
	}
}

