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
			throw new System.NotImplementedException();
		}

		public override int Count {
			get {
				return 3;
			}
		}

		/*
		public override Java.Lang.ICharSequence GetPageTitleFormatted(int p0) {
			return new Java.Lang.String(string.Format("Section {0}", p0));
		}
		*/
	}

}


