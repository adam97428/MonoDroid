using System;
using System.Linq;
using Android.Widget;
using Android.Views;
using Android.App;
using Android.Graphics.Drawables;
using Android.Content;

namespace MonoDroid.Attributes {

	public class SampleAdapter : BaseAdapter<Sample> {

		private Sample[] _samples;
		Activity _context;

		public SampleAdapter(Activity context) {
			this._context = context;
			this.FindAppSamples();
		}

		void FindAppSamples() {
			var assembly = this._context.GetType().Assembly;
			var samples = from t in assembly.GetTypes()
				where typeof(Activity).IsAssignableFrom(t) && t.GetCustomAttributes(typeof(SampleAttribute), false).Length > 0
					select BuildSample(t);
			this._samples = samples.ToArray();
		}

		private Sample BuildSample(Type activityType) {
			var sample = new Sample();
			sample.Launch = activityType;

			var attr = (ActivityAttribute)activityType.GetCustomAttributes(typeof(ActivityAttribute), false)[0];
			sample.Label = attr.Label;

			return sample;
		}

		public override long GetItemId(int position) {
			return position;
		}

		public override View GetView(int position, View convertView, ViewGroup parent) {
			var itemView = convertView as LinearLayout;
			if (itemView == null) {
				itemView = (LinearLayout)this._context.LayoutInflater.Inflate(Resource.Layout.activity_main_list_item, parent, false);
			}
			var sample = this[position];

			var imageView = itemView.FindViewById<ImageView>(Resource.Id.activity_main_list_item_imageview);

			var cxt = this._context;
			var pm = cxt.PackageManager;
			var actIcon = pm.GetActivityIcon(new Intent(cxt, sample.Launch));
			imageView.SetImageDrawable(actIcon);

			var textView = itemView.FindViewById<TextView>(Resource.Id.activity_main_list_item_textview);
			textView.Text = sample.Label;

			itemView.Tag = sample;
			return itemView;
		}

		public override int Count {
			get {
				return this._samples.Length;
			}
		}

		public override Sample this[int position] {
			get {
				return this._samples[position];
			}
		}
	}
}
