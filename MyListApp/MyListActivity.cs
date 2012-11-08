using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace MyListApp {

	[Activity (Label = "MyListApp", MainLauncher = true)]
	public class MyListActivity : ListActivity {

		protected override void OnCreate(Bundle bundle) {
			base.OnCreate(bundle);

			// Create your application here
			var countries = Resources.GetStringArray(Resource.Array.CountryArray);
			this.ListAdapter = new ArrayAdapter<string>(this, Resource.Layout.MyListActivityItem, countries);
			this.ListView.TextFilterEnabled = true;
			
			this.ListView.ItemClick += (object sender, AdapterView.ItemClickEventArgs e) => {
				var toast = Toast.MakeText(this.Application, ((TextView)e.View).Text, ToastLength.Short);
				toast.Show();
			};
		}
	}
}

