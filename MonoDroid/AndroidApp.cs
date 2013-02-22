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
				return this.IsLargeScreen() ? ScreenOrientation.Landscape : ScreenOrientation.Portrait;
			}
		}

		public bool IsLargeScreen() {
			var dm = this.Resources.DisplayMetrics;
			var scaledDencity = dm.ScaledDensity;
			var widthScaled = dm.WidthPixels / scaledDencity;
			var heightScaled = dm.HeightPixels / scaledDencity;
			var isTablet = widthScaled > 960 && heightScaled > 720;
			return isTablet;
		}

		public int GenerateViewId() {
			return IdGeneragor.GenerateId();
		}

	}

	public static class IdGeneragor {
		
		private static volatile int _currentId = int.MaxValue;
		
		public static int GenerateId() {
			return --IdGeneragor._currentId;
		}
	}

}

