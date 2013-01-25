using System;
using Android.App;
using Android.Runtime;
using Android.Content.PM;
using Android.Content.Res;

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
				var dm = this.Resources.DisplayMetrics;
				var dencity = dm.Density;
				var scaledDencity = dm.ScaledDensity;

				var widthPx = dm.WidthPixels;
				var heightPx = dm.HeightPixels;

				var widthScaled = widthPx / scaledDencity;
				var heightScaled = heightPx / scaledDencity;

				var orientation = this.Resources.Configuration.Orientation;
				// 如果设备现在是横屏
				if (orientation == Orientation.Landscape) {
					// 经过缩放后的宽度小于480，竖屏显示，否则横屏显示
					if (widthScaled <= 480) {
						return ScreenOrientation.Portrait;
					}
					else {
						return ScreenOrientation.Landscape;
					}
				}
				// 如果设备现在是竖屏
				else if (orientation == Orientation.Portrait) {
					// 如果缩放后的宽度大于768，横屏显示，否则竖屏显示
					if (widthScaled >= 768) {
						return ScreenOrientation.Landscape;
					}
					else {
						return ScreenOrientation.Portrait;
					}
				}
				// 方的以及未定义的怎么办？（横屏）
				else if (orientation == Orientation.Square) {
					return ScreenOrientation.Landscape;
				}
				else {
					return ScreenOrientation.Landscape;
				}

			}
		}
	}
}

