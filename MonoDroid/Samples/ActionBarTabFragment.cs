
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MonoDroid.Attributes;

namespace MonoDroid.Samples {

	[Sample(Label = "Action Bar Tabs")]
	public class ActionBarTabFragment : Android.Support.V4.App.Fragment {

		private IList<ActionBar.Tab> _tabs;
		private ActionBarNavigationMode _navMode;

		private Android.Support.V4.View.ViewPager _viewPager;
		private DummySectionsPagerAdapter _adapter;

		public override void OnCreate(Bundle savedInstanceState) {
			base.OnCreate(savedInstanceState);
			this.SetHasOptionsMenu(true);
		}

		public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) {
			var view = inflater.Inflate(Resource.Layout.fragment_actionbar_tabs, container, false);
			this._viewPager = view.FindViewById<Android.Support.V4.View.ViewPager>(Resource.Id.fragment_actionbar_tabs_viewpager);
			this._viewPager.PageSelected += (object sender, Android.Support.V4.View.ViewPager.PageSelectedEventArgs e) => {
				var actionBar = this.Activity.ActionBar;
				actionBar.SetSelectedNavigationItem(e.P0);
			};
			this._adapter = new DummySectionsPagerAdapter(this.FragmentManager);
			this._viewPager.Adapter = this._adapter;
			return view;
		}

		public override void OnStart() {
			base.OnStart();

			var actionBar = this.Activity.ActionBar;
			this._navMode = actionBar.NavigationMode;
			actionBar.NavigationMode = ActionBarNavigationMode.Tabs;


			this._tabs = new List<ActionBar.Tab>();

			
			for (var i = 0; i < 3; i++) {
				var tab = actionBar.NewTab().SetText("Section " + (i + 1));
				tab.TabSelected += delegate {
					if (this._viewPager.CurrentItem != tab.Position) {
						this._viewPager.CurrentItem = tab.Position;
					}
				};
				actionBar.AddTab(tab);
				this._tabs.Add(tab);
			}
		}

		public override void OnStop() {
			base.OnStop();
			var actionBar = this.Activity.ActionBar;

			foreach (var tab in _tabs) {
				actionBar.RemoveTab(tab);
				tab.Dispose();
			}
			this._tabs.Clear();

			actionBar.NavigationMode = this._navMode;
		}
	}

	public class DummySectionsPagerAdapter : Android.Support.V4.App.FragmentPagerAdapter {

		public DummySectionsPagerAdapter(Android.Support.V4.App.FragmentManager fm) : base(fm) {
		}

		public override Android.Support.V4.App.Fragment GetItem(int position) {
			var fragment = new DummySectionFragment();
			var args = new Bundle();
			args.PutInt(DummySectionFragment.ArgSectionNumber, position + 1);
			fragment.Arguments = args;
			return fragment;
		}

		public override int Count {
			get {
				return 3;
			}
		}
		
		public override Java.Lang.ICharSequence GetPageTitleFormatted(int p0) {
			return new Java.Lang.String(string.Format("Section {0}", p0));
		}
	}

	public class DummySectionFragment : Android.Support.V4.App.Fragment {
		
		public static readonly string ArgSectionNumber = "SectionNumber";
		
		public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) {
			var rootView = inflater.Inflate(Resource.Layout.fragment_actionbar_tabs_item, container, false);
			var args = this.Arguments;
			var textView = rootView.FindViewById<TextView>(Android.Resource.Id.Text1);
			textView.Text = string.Format("Section {0} is just a dummy section.", args.GetInt(ArgSectionNumber));
			return rootView;
		}
	}
}

