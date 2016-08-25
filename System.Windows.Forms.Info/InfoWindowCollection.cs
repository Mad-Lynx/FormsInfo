using System.Collections;

namespace System.Windows.Forms.Info
{
	internal class InfoWindowCollection
	{
		private readonly Hashtable collection = new Hashtable();

		public void Add(Form form, IInfoWindow infoWindow)
		{
			lock (collection)
			{
				collection[form] = infoWindow;
			}
		}

		public void Remove(Form form)
		{
			lock (collection)
			{
				collection.Remove(form);
			}
		}

		public IInfoWindow this[Form index]
		{
			get
			{
				lock (collection)
				{
					return (IInfoWindow)collection[index];
				}
			}
		}
	}
}
