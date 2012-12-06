using Android.Support.V4.App;
using Android.OS;

namespace EffectiveNavigation {

	/// <summary>
	/// A {@link android.support.v4.app.FragmentStatePagerAdapter} that returns a fragment
	/// representing an object in the collection.
	/// </summary>
	public class DemoCollectionPagerAdapter : FragmentStatePagerAdapter {

		public DemoCollectionPagerAdapter(FragmentManager fm) : base(fm) {
		}

		public override Fragment GetItem(int i) {
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
