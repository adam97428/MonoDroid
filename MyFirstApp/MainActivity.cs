using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Reflection;

namespace Cn.Beginor.MyFirstApp {

	[Activity(Label = "MyFirstApp", MainLauncher = true)]
	public class MainActivity : Activity {
		
		public const string ExtraMessage = "Cn.Beginor.MyFirstApp.MainActivity.ExtraMessage";
		
		protected override void OnCreate(Bundle bundle) {
			base.OnCreate(bundle);
			// 设置布局文件
			this.SetContentView(Resource.Layout.MainActivity);
			var sendBtn = this.FindViewById<Button>(Resource.Id.SendButton);
			// 为发送按钮添加事件处理函数
			sendBtn.Click += SendButtonClick;
			Android.Util.Log.Debug("Debug", this.GetType().Name + "." + MethodBase.GetCurrentMethod().Name);
		}
		
		void SendButtonClick (object sender, EventArgs e) {
			// 获取用户输入的信息
			var msgEditText = this.FindViewById<EditText>(Resource.Id.MessageEditText);
			if (msgEditText == null) {
				return;
			}
			var msg = msgEditText.Text;
			// 创建 Intent 并传递用户输入的信息
			var intent = new Intent(this, typeof(SecondActivity));
			intent.PutExtra(ExtraMessage, msg);
			// 启动第二个 Activity
			this.StartActivity(intent);
		}

		protected override void OnStart() {
			base.OnStart();
			Android.Util.Log.Debug("Debug", this.GetType().Name + "." + MethodBase.GetCurrentMethod().Name);
		}

		protected override void OnResume() {
			base.OnResume();
			Android.Util.Log.Debug("Debug", this.GetType().Name + "." + MethodBase.GetCurrentMethod().Name);
		}

		protected override void OnPause() {
			base.OnPause();
			Android.Util.Log.Debug("Debug", this.GetType().Name + "." + MethodBase.GetCurrentMethod().Name);
		}

		protected override void OnStop() {
			base.OnStop();
			Android.Util.Log.Debug("Debug", this.GetType().Name + "." + MethodBase.GetCurrentMethod().Name);
		}

		protected override void OnRestart() {
			base.OnRestart();
			Android.Util.Log.Debug("Debug", this.GetType().Name + "." + MethodBase.GetCurrentMethod().Name);
		}

		protected override void OnDestroy() {
			base.OnDestroy();
			Android.Util.Log.Debug("Debug", this.GetType().Name + "." + MethodBase.GetCurrentMethod().Name);
			Android.Util.Log.Debug("Debug", this.GetType().Name + ".IsFinishing = " + this.IsFinishing);
		}
	}
}


