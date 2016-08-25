using System.Runtime.CompilerServices;

namespace System.Windows.Forms.Info
{
	internal class InfoWindowCollection
	{
		private readonly ConditionalWeakTable<Form, IInfoWindow> collection = new ConditionalWeakTable<Form, IInfoWindow>();

		public IInfoWindow this[Form index]
		{
			get
			{
				IInfoWindow infoWindow;
				collection.TryGetValue(index, out infoWindow);
				return infoWindow;
			}
		}

		public void Add(Form form, IInfoWindow infoWindow)
		{
			collection.Add(form, infoWindow);
			form.FormClosed += FormOnFormClosed;
		}

		private void FormOnFormClosed(object sender, FormClosedEventArgs args)
		{
			this[(Form)sender]?.Close();
		}

		public void Remove(Form form)
		{
			form.FormClosed -= FormOnFormClosed;
			collection.Remove(form);
		}

	}
}