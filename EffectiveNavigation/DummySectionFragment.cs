using Android.OS;
using Android.Views;
using Android.Widget;
using Android.Support.V4.App;

namespace EffectiveNavigation {

	/// <summary>
	/// A dummy fragment representing a section of the app, but that simply
	/// displays dummy text.
	/// </summary>
	public class DummySectionFragment : Fragment {

		public static readonly string ArgSectionNumber = "SectionNumber";

		public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) {
			var rootView = inflater.Inflate(Resource.Layout.FragmentSectionDummy, container, false);
			var args = this.Arguments;
			var textView = rootView.FindViewById<TextView>(Android.Resource.Id.Text1);
			textView.Text = this.GetString(Resource.String.DummySectionText, args.GetInt(ArgSectionNumber));
			return rootView;
		}
	}
}

