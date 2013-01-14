using Android.OS;
using Android.Views;
using Android.Widget;
using MonoDroid.Attributes;

namespace MonoDroid.Fragments {

	public class MenuFragment : Android.Support.V4.App.Fragment {

		public override View OnCreateView(LayoutInflater p0, ViewGroup p1, Bundle p2) {
			var view = p0.Inflate(Resource.Layout.fragment_menu, p1, false);

			var listView = view.FindViewById<ListView>(Resource.Id.fragment_ment_listview);
			listView.Adapter = new SampleAdapter(this.Activity);
			var activity = this.Activity;

			var listener = activity as ListView.IOnItemClickListener;
			if (listener != null) {
				listView.OnItemClickListener = listener;
			}

			return view;
		}
	}
}

