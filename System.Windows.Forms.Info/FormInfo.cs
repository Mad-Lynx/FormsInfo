namespace System.Windows.Forms.Info
{
	public static class FormInfo
	{
		public static readonly IMessageFilter MessageFilter = new WindowInfoMessageFilter();
		public static readonly ImageCollection ImageCollection = new ImageCollection();
		internal static readonly InfoWindowCollection InfoWindows = new InfoWindowCollection();

		static FormInfo()
		{
			RegisterImages();
			RegisterTypes();
		}

		public static void RegisterMessageFilter()
		{
			Application.AddMessageFilter(MessageFilter);
		}

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

			var wi = InfoWindows[parentForm] ?? new InfoWindow(parentForm);

			wi.RebuidInfo(control);
			wi.Show();
		}

		private static void ChangeControl(Form parentForm, Control parentControl)
		{
			if (parentForm == null)
				return;

			InfoWindows[parentForm]?.ChangeControl(parentControl);
		}

		private static void RegisterImages()
		{
			ResourceManager.GetImages().ForEach(i => ImageCollection.RegisterImage((string)i.Tag, i));
		}

		private static void RegisterTypes()
		{
			// Register standard types and imageKey
			ImageCollection.RegisterType<Control>("Control");
			ImageCollection.RegisterType<Form>("Form");
			ImageCollection.RegisterType<RadioButton>("RadioButton");
			ImageCollection.RegisterType<CheckBox>("CheckBox");
			ImageCollection.RegisterType<ButtonBase>("Button");
			ImageCollection.RegisterType<ComboBox>("ComboBox");
			ImageCollection.RegisterType<ListBox>("ListBox");
			//ImageCollection.RegisterType<ListControl>("ListControl");
			ImageCollection.RegisterType<GroupBox>("GroupBox");
			ImageCollection.RegisterType<TabPage>("TabPage");
			ImageCollection.RegisterType<FlowLayoutPanel>("LayoutPanel");
			ImageCollection.RegisterType<TableLayoutPanel>("LayoutPanel");
			ImageCollection.RegisterType<Panel>("Panel");
			ImageCollection.RegisterType<TabControl>("TabControl");
			ImageCollection.RegisterType<TextBoxBase>("TextBox");
			//ImageCollection.RegisterType<MaskedTextBox>("MaskedTextBox");
			//ImageCollection.RegisterType<PasswordBox>("PasswordBox");
			ImageCollection.RegisterType<Label>("Label");
			ImageCollection.RegisterType<ProgressBar>("ProgressBar");
			ImageCollection.RegisterType<DateTimePicker>("DateTimePicker");
			ImageCollection.RegisterType<DataGrid>("DataGrid");
			ImageCollection.RegisterType<UserControl>("UserControl");
			ImageCollection.RegisterType<Splitter>("Splitter");
			ImageCollection.RegisterType<ScrollableControl>("ScrollableControl");
		}
	}
}