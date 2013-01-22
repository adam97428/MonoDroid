
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
using MonoDroid.Attributes;

namespace MonoDroid.Samples {

	[Sample(Label = "Fragment Navigation")]
	public class NavigationFragment : Android.Support.V4.App.Fragment {

		public const string ExtraMessage = "MonoDroid.Samples.NavigationFragment.ExtraMessage";

		public override void OnCreate(Bundle savedInstanceState) {
			base.OnCreate(savedInstanceState);

			// Create your fragment here
		}

		public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) {
			var view = inflater.Inflate(Resource.Layout.fragment_navigation, container, false);

			var btn = view.FindViewById<Button>(Resource.Id.fragment_navigation_button);
			btn.Click += OnButtonClick;
			return view;
		}

		void OnButtonClick(object sender, EventArgs e) {
			var editText = this.View.FindViewById<EditText>(Resource.Id.fragment_navigation_edittext);
			if (editText == null) {
				return;
			}

			var target = new NavigationTargetFragment();
			if (target.Arguments == null) {
				target.Arguments = new Bundle();
			}
			target.Arguments.PutString(ExtraMessage, editText.Text);

			MainActivity.Current.PushFragment(target);
		}
	}

	public class NavigationTargetFragment : Android.Support.V4.App.Fragment {

		public override void OnCreate(Bundle savedInstanceState) {
			base.OnCreate(savedInstanceState);
			
			// Create your fragment here
		}
		
		public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) {
			var view = inflater.Inflate(Resource.Layout.fragment_navigation_target, container, false);
			var textView = view.FindViewById<TextView>(Resource.Id.fragment_navigation_target_textview);
			var msg = this.Arguments.GetString(NavigationFragment.ExtraMessage);
			textView.Text = msg;
			return view;
		}
	}
}

