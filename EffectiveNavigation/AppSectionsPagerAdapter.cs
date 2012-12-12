using Android.OS;
using Android.Support.V4.App;

namespace EffectiveNavigation {

	/// <summary>
	/// A {@link FragmentPagerAdapter} that returns a fragment corresponding to
	/// one of the primary sections of the app.
	/// </summary>
	public class AppSectionsPagerAdapter : FragmentPagerAdapter {

		public AppSectionsPagerAdapter(FragmentManager fm) : base(fm) {
		}

		public override Fragment GetItem(int p) {
			switch (p) {
			case 0:
				// The first section of the app is the most interesting -- it offers
				// a launchpad into the other demonstrations in this example application.
				return new LaunchpadSectionFragment();
			default:
				// The other sections of the app are dummy placeholders.
				var fragment = new DummySectionFragment();
				var args = new Bundle();
				args.PutInt(DummySectionFragment.ArgSectionNumber, p + 1);
				fragment.Arguments = args;
				return fragment;
			}
		}

		public override int Count {
			get {
				return 3;
			}
		}

		public override Java.Lang.ICharSequence GetPageTitleFormatted(int p0) {
			return new Java.Lang.String(string.Format("Section {0}", p0));
		}

	}
}


