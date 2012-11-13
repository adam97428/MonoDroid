
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Content.Res;

namespace MyListApp {

	public class MyListAdapter : BaseAdapter<string> {

		private string[] _data;
		private Activity _activity;

		public MyListAdapter(Activity activity) {
			this._activity = activity;
			this._data = activity.Resources.GetStringArray(Resource.Array.CountryArray);
		}

		public override long GetItemId(int position) {
			return position;
		}

		public override View GetView(int position, View convertView, ViewGroup parent) {
			TextView view = convertView as TextView;
			if (view == null) {
				view = (TextView)this._activity.LayoutInflater.Inflate(Resource.Layout.MyListActivityItem, null);
			}
			view.Text = this._data[position];
			return view;
		}

		public override int Count {
			get {
				return this._data.Length;
			}
		}

		public override string this[int position] {
			get {
				return this._data[position];
			}
		}

	}
}

