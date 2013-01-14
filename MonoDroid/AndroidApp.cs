using System;
using Android.App;
using Android.Runtime;

namespace MonoDroid {

	[Application]
	public class AndroidApp : Application {

		public AndroidApp(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer) {
		}

		public override void OnCreate() {
			base.OnCreate();
		}
	}
}

