
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Cn.Beginor.MyFirstApp {

	[Activity (Label = "SecondActivity")]
	public class SecondActivity : Activity {

		protected override void OnCreate(Bundle bundle) {
			base.OnCreate(bundle);

			this.SetContentView(Resource.Layout.SecondActivityLayout);

			var intent = this.Intent;
			var msg = intent.GetStringExtra(MainActivity.ExtraMessage);

			var textView = this.FindViewById<TextView>(Resource.Id.MessageTextView);
			textView.Text = msg;

			var shutDownButton = this.FindViewById<Button>(Resource.Id.ShutDownButton);
			shutDownButton.Click += TryShutdown;
		}

		void TryShutdown (object sender, EventArgs e) {
			Task.Factory.StartNew(() => {
				try {
					Instrumentation inst = new Instrumentation();
					var pownDown = new KeyEvent(KeyEventActions.Down, Keycode.Power);
					var pownUp = new KeyEvent(KeyEventActions.Up, Keycode.Power);
					inst.SendKeySync(pownDown);
					Thread.Sleep(TimeSpan.FromSeconds(2));
					inst.SendKeySync(pownUp);
				}
				catch (Exception ex) {
					Console.WriteLine(ex.ToString());
				}
			});
		}
	}
}

