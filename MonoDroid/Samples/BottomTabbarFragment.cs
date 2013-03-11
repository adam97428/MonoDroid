
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace MonoDroid.Samples {

	[MonoDroid.Attributes.Sample(Label = "Bottom Tabbar with RadioGroup")]
	public class BottomTabbarFragment : Android.Support.V4.App.Fragment {

		public override void OnCreate(Bundle savedInstanceState) {
			base.OnCreate(savedInstanceState);

			// Create your fragment here
		}

		public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) {
			var view = inflater.Inflate(Resource.Layout.fragment_bottom_tabbar, container, false);
			return view;
		}
	}

}

