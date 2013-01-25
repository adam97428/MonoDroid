
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

		public override void OnCreate(Bundle savedInstanceState) {
			base.OnCreate(savedInstanceState);
			this.SetHasOptionsMenu(true);
		}

		public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) {
			return base.OnCreateView(inflater, container, savedInstanceState);
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
					//tab.Position;
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
}

