using System;
using MonoDroid.Attributes;
using Android.Views;

namespace MonoDroid.Samples {

	[Sample(Label = "Pager Tabs")]
	public class PagerTabStripFragment : Android.Support.V4.App.Fragment {

		private Android.Support.V4.View.ViewPager _viewPager;
		private Android.Support.V4.View.PagerTabStrip _pagerTabStrip;

		private DummySectionsPagerAdapter _adapter;


		public override View OnCreateView(LayoutInflater p0, ViewGroup p1, Android.OS.Bundle p2) {
			var view = p0.Inflate(Resource.Layout.fragment_pager_tabstrip_tabs, p1, false);
			this._viewPager = view.FindViewById<Android.Support.V4.View.ViewPager>(Resource.Id.fragment_pager_tabstrip_viewpager);
			//this._viewPager.PageSelected += (object sender, Android.Support.V4.View.ViewPager.PageSelectedEventArgs e) => {
				//var actionBar = this.Activity.ActionBar;
				//actionBar.SetSelectedNavigationItem(e.P0);
			//};
			this._adapter = new DummySectionsPagerAdapter(this.FragmentManager);
			this._viewPager.Adapter = this._adapter;

			this._pagerTabStrip = view.FindViewById<Android.Support.V4.View.PagerTabStrip>(Resource.Id.fragment_pagertabstrip_tabstrip);

			return view;
		}
	}
}

