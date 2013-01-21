using System;

namespace MonoDroid.Attributes {

	public class SampleAttribute : Attribute {

		public string Label {
			get;
			set;
		}

		public SampleAttribute() {
		}
	}

}

