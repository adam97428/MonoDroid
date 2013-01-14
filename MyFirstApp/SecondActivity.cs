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
using System.Reflection;

namespace Cn.Beginor.MyFirstApp {

	[Activity (Label = "SecondActivity")]
	public class SecondActivity : Activity {

		protected override void OnCreate(Bundle bundle) {
			base.OnCreate(bundle);
			// // 设置布局文件
			this.SetContentView(Resource.Layout.SecondActivity);
			// 从 Intent 中获取 ExtraMessage 
			var intent = this.Intent;
			var msg = intent.GetStringExtra(MainActivity.ExtraMessage);
			// 将 ExtraMessage 显示在 TextView 上
			var textView = this.FindViewById<TextView>(Resource.Id.MessageTextView);
			textView.Text = msg;
			Android.Util.Log.Debug("Debug", this.GetType().Name + "." + MethodBase.GetCurrentMethod().Name);
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

