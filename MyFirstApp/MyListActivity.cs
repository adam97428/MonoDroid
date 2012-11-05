
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

		private readonly string[] _countries = new String[] {
			"Afghanistan","Albania","Algeria","American Samoa","Andorra",
			"Angola","Anguilla","Antarctica","Antigua and Barbuda","Argentina",
			"Armenia","Aruba","Australia","Austria","Azerbaijan",
			"Bahrain","Bangladesh","Barbados","Belarus","Belgium",
			"Belize","Benin","Bermuda","Bhutan","Bolivia",
			"Bosnia and Herzegovina","Botswana","Bouvet Island","Brazil",
			"British Indian Ocean Territory"
		};

		protected override void OnCreate(Bundle bundle) {
			base.OnCreate(bundle);

			// Create your application here
			this.ListAdapter = new ArrayAdapter<string>(this, Resource.Layout.MyListActivityItemLayout, this._countries);
			this.ListView.TextFilterEnabled = true;

			this.ListView.ItemClick += (object sender, AdapterView.ItemClickEventArgs e) => {
				var toast = Toast.MakeText(this.Application, ((TextView)e.View).Text, ToastLength.Short);
				toast.Show();
			};
		}
	}
}

