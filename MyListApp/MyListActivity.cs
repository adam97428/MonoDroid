using Android.App;
using Android.Widget;
using Android.OS;

namespace MyListApp {

	[Activity (Label = "MyListApp", MainLauncher = true)]
	public class MyListActivity : ListActivity {

		protected override void OnCreate(Bundle bundle) {
			base.OnCreate(bundle);

			// Create your application here
			var arrayAdapter = new MyListAdapter(this);
			this.ListAdapter = arrayAdapter;
			this.ListView.TextFilterEnabled = true;
			
			this.ListView.ItemClick += (object sender, AdapterView.ItemClickEventArgs e) => {
				var toast = Toast.MakeText(this.Application, ((TextView)e.View).Text, ToastLength.Short);
				toast.Show();
			};
		}
	}
}


