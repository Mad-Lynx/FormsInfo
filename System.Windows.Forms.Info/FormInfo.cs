namespace System.Windows.Forms.Info
{
	public static class FormInfo
	{
		public static readonly IMessageFilter MessageFilter = new WindowInfoMessageFilter();
		internal static readonly InfoWindowCollection InfoWindows = new InfoWindowCollection();

		public static void Show(Control control)
		{
			Show(control.FindForm(), control);
		}

		public static void ChangeControl(Control control)
		{
			ChangeControl(control.FindForm(), control);
		}

		private static void Show(Form parentForm, Control control)
		{
			if (parentForm == null)
				return;

			var wi = InfoWindows[parentForm];
			if (wi == null)
				wi = new InfoWindow(parentForm);

			wi.RebuidInfo(control);
			wi.Show();
		}

		private static void ChangeControl(Form parentForm, Control parentControl)
		{
			if (parentForm == null)
				return;

			var wi = InfoWindows[parentForm];
			if (wi != null)
				wi.ChangeControl(parentControl);
		}

	}
}
