
using System;

using Android.OS;
using Android.Views;
using Android.Widget;
using MonoDroid.Attributes;

namespace MonoDroid.Samples {

	[Sample(Label = "Fragment Navigation")]
	public class NavigationFragment : Android.Support.V4.App.Fragment {

		public const string ExtraMessage = "MonoDroid.Samples.NavigationFragment.ExtraMessage";

		private const string UserInput = "UserInput";
		private string _userInputText;

		public override void OnCreate(Bundle savedInstanceState) {
			base.OnCreate(savedInstanceState);

			// Create your fragment here
			if (savedInstanceState != null) {
				this._userInputText = savedInstanceState.GetString(UserInput);
			}
		}

		public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) {
			var view = inflater.Inflate(Resource.Layout.fragment_navigation, container, false);
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

		public override void OnStart() {
			base.OnStart();
			if (this._userInputText != null) {
				var editText = this.View.FindViewById<EditText>(Resource.Id.fragment_navigation_edittext);
				editText.Text = this._userInputText;
			}
		}

		public override void OnSaveInstanceState(Bundle p0) {
			var input = this.View.FindViewById<EditText>(Resource.Id.fragment_navigation_edittext);
			if (!string.IsNullOrEmpty(input.Text)) {
				p0.PutString(UserInput, input.Text);
			}
		}

		public override void OnResume() {
			base.OnResume();
			var btn = this.View.FindViewById<Button>(Resource.Id.fragment_navigation_button);
			btn.Click += OnButtonClick;
		}

		public override void OnPause() {
			base.OnPause();
			var btn = this.View.FindViewById<Button>(Resource.Id.fragment_navigation_button);
			btn.Click -= OnButtonClick;
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

