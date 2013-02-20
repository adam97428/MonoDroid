using System;
using Android.App;
using Android.Runtime;
using Android.Content.PM;

namespace MonoDroid {

	[Application(UiOptions = UiOptions.SplitActionBarWhenNarrow)]
	public class AndroidApp : Application {

		public static AndroidApp CurrentApp {
			get;
			private set;
		}

		public AndroidApp(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer) {
		}

		public override void OnCreate() {
			base.OnCreate();
			CurrentApp = this;
		}

		public ScreenOrientation ScreenOrientation {
			get {
				return this.IsTablet ? ScreenOrientation.Landscape : ScreenOrientation.Portrait;
			}
		}

		public bool IsTablet {
			get {
				var dm = this.Resources.DisplayMetrics;
				var scaledDencity = dm.ScaledDensity;
				var widthScaled = dm.WidthPixels / scaledDencity;
				var heightScaled = dm.HeightPixels / scaledDencity;
				var isTablet = widthScaled > 960 && heightScaled > 720;
				return isTablet;
			}
		}
	}
}

