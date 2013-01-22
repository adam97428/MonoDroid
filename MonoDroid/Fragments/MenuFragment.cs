using Android.Widget;
using MonoDroid.Attributes;
using Android.Views;

namespace MonoDroid.Fragments {

	public class MenuFragment : Android.Support.V4.App.ListFragment {

		public override void OnStart() {
			base.OnStart();
			var activity = this.Activity;
			this.ListAdapter = new SampleAdapter(activity);
			/*
			var listener = activity as ListView.IOnItemClickListener;
			if (listener != null) {
				this.ListView.OnItemClickListener = listener;
			}
			*/
		}

		public override void OnListItemClick(ListView listView, View view, int position, long id) {
			base.OnListItemClick(listView, view, position, id);
			var sample = view.Tag as Sample;
			if (sample != null) {
				MainActivity.Current.ShowSample(sample);
			}
		}
	}
}

