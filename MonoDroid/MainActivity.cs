using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using MonoDroid.Attributes;

namespace MonoDroid {

	[Activity (Label = "@string/app_name", MainLauncher = true)]
	public class MainActivity : ListActivity {

		protected override void OnCreate(Bundle bundle) {
			base.OnCreate(bundle);

			this.ListAdapter = new SampleAdapter(this);

			this.ListView.ItemClick += OnListItemClick;
		}

		void OnListItemClick(object sender, AdapterView.ItemClickEventArgs e) {
			var sample = e.View.Tag as Sample;
			if (sample != null) {
				var intent = new Intent(this, sample.Launch);
				this.StartActivity(intent);
			}
			else {
				Toast.MakeText(this, "Error: Sample is empty!", ToastLength.Short);
			}
		}
		
	}
}


