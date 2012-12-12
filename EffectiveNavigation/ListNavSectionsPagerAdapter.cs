using Android.OS;
using Android.Support.V4.App;

namespace EffectiveNavigation {

	/// <summary>
	/// A {@link FragmentPagerAdapter} that returns a fragment corresponding to
	/// one of the primary sections of the app.
	/// </summary>
	public class ListNavSectionsPagerAdapter : FragmentPagerAdapter {

		public ListNavSectionsPagerAdapter(FragmentManager sm) : base(sm) {
		}

		public override Fragment GetItem(int p) {
			var fragment = new DummySectionFragment();
			var args = new Bundle();
			args.PutInt(DummySectionFragment.ArgSectionNumber, p + 1);
			fragment.Arguments = args;
			return fragment;
		}

		public override int Count {
			get {
				return 3;
			}
		}

		public override Java.Lang.ICharSequence GetPageTitleFormatted(int p) {
			return new Java.Lang.String(string.Format("Section {0}", p));
		}

	}
}
