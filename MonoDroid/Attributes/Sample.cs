using System;
using System.Linq;
using Android.Widget;
using Android.Views;
using Android.App;
using Android.Graphics.Drawables;
using Android.Content;

namespace MonoDroid.Attributes {

	public class Sample : Java.Lang.Object {

		public Type Launch {
			get;
			set;
		}

		public string Label {
			get;
			set;
		}

		public Drawable Icon {
			get;
			set;
		}
	}
	
}
