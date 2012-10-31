using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace Cn.Beginor.MyFirstApp {

	[Activity (Label = "MyFirstApp", MainLauncher = true)]
	public class MainActivity : Activity {

		public const string ExtraMessage = "Cn.Beginor.MyFirstApp.MainActivity.ExtraMessage";

		protected override void OnCreate(Bundle bundle) {
			base.OnCreate(bundle);

			this.SetContentView(Resource.Layout.MainActivityLayout);

			var sendBtn = this.FindViewById<Button>(Resource.Id.SendButton);

			sendBtn.Click += SendButtonClick;
		}

		void SendButtonClick (object sender, EventArgs e) {
			var msgEditText = this.FindViewById<EditText>(Resource.Id.MessageEditText);
			if (msgEditText == null) {
				return;
			}
			var msg = msgEditText.Text;

			var intent = new Intent(this, typeof(SecondActivity));
			intent.PutExtra(ExtraMessage, msg);

			this.StartActivity(intent);
		}
	}
}


