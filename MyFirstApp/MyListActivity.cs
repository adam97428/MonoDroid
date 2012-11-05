
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Cn.Beginor.MyFirstApp {

	[Activity(Label = "ListDemo", MainLauncher = true)]
	public class MyListActivity : ListActivity {

		protected override void OnCreate(Bundle bundle) {
			base.OnCreate(bundle);

			// Create your application here
			var countries = Resources.GetStringArray(Resource.Array.CountryArray);
			this.ListAdapter = new ArrayAdapter<string>(this, Resource.Layout.MyListActivityItemLayout, countries);
			this.ListView.TextFilterEnabled = true;

			this.ListView.ItemClick += (object sender, AdapterView.ItemClickEventArgs e) => {
				var toast = Toast.MakeText(this.Application, ((TextView)e.View).Text, ToastLength.Short);
				toast.Show();
			};
		}
	}
}

