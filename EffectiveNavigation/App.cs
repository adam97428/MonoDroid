using System;
using Android.App;
using Android.Runtime;

namespace EffectiveNavigation {

	[Application(Label = "@string/AppName", Icon = "@drawable/ic_launcher",
					 Theme = "@android:style/Theme.Holo.Light.DarkActionBar")]
	public class App : Application {

		public App(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer) {
		}
	}
}

