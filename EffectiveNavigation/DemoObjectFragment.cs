using Android.Support.V4.App;
using Android.Views;
using Android.OS;
using Android.Widget;

namespace EffectiveNavigation {

	/// <summary>
	/// A dummy fragment representing a section of the app, but that simply displays dummy text.
	/// </summary>
	public class DemoObjectFragment : Fragment {

		public static readonly string ArgObject = "Object";

		public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) {
			var rootView = inflater.Inflate(Resource.Layout.FragmentCollectionObject, container, false);
			var arg = this.Arguments;
			var textView = rootView.FindViewById<TextView>(Android.Resource.Id.Text1);
			textView.Text = arg.GetInt(ArgObject).ToString();
			return rootView;
		}
	}
}
