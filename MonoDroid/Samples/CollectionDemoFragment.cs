using Android.OS;
using Android.Views;
using Android.Widget;
using MonoDroid.Attributes;
using Android.Support.V4.View;

namespace MonoDroid.Samples {

	[Sample(Label = "Collection Demo")]
	public class CollectionDemoFragment : Android.Support.V4.App.Fragment {

		private DemoCollectionPagerAdapter _adapter;
		private ViewPager _viewPager;

		public override void OnCreate(Bundle savedInstanceState) {
			base.OnCreate(savedInstanceState);

			// Create your fragment here
			this.SetHasOptionsMenu(true);
			this._adapter = new DemoCollectionPagerAdapter(this.Activity.SupportFragmentManager);
		}

		public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) {
			var view = inflater.Inflate(Resource.Layout.fragment_collection_demo, container, false);
			this._viewPager = view.FindViewById<ViewPager>(Resource.Id.fragment_collection_demo_viewpager);
			this._viewPager.Adapter = this._adapter;
			return view;
		}
	}

	public class DemoObjectFragment : Android.Support.V4.App.Fragment {

		public static readonly string ArgObject = "Object";

		public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle p2) {
			var rootView = inflater.Inflate(Resource.Layout.fragment_collection_object, container, false);
			var arg = this.Arguments;
			var textView = rootView.FindViewById<TextView>(Android.Resource.Id.Text1);
			textView.Text = arg.GetInt(ArgObject).ToString();
			return rootView;
		}

	}

	public class DemoCollectionPagerAdapter : Android.Support.V4.App.FragmentStatePagerAdapter {

		public DemoCollectionPagerAdapter(Android.Support.V4.App.FragmentManager fm) : base(fm) {
		}

		public override Android.Support.V4.App.Fragment GetItem(int i) {
			var fragment = new DemoObjectFragment();
			var bundle = new Bundle();
			// Our object is just an integer :-P
			bundle.PutInt(DemoObjectFragment.ArgObject, i);
			fragment.Arguments = bundle;
			return fragment;
		}
		
		// For this contrived example, we have a 100-object collection.
		public override int Count {
			get {
				return 100;
			}
		}
		
		public override Java.Lang.ICharSequence GetPageTitleFormatted(int i) {
			return new Java.Lang.String(string.Format("OBJECT {0}", i + 1));
		}
	}
}

