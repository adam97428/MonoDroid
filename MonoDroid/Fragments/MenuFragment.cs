using Android.Widget;
using MonoDroid.Attributes;

namespace MonoDroid.Fragments {

	public class MenuFragment : Android.Support.V4.App.ListFragment {

		public override void OnStart() {
			base.OnStart();
			var activity = this.Activity;
			this.ListAdapter = new SampleAdapter(activity);
			var listener = activity as ListView.IOnItemClickListener;
			if (listener != null) {
				this.ListView.OnItemClickListener = listener;
			}
		}
	}
}

