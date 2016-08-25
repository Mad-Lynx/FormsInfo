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

		static FormInfo()
		{
			ResourceManager.GetImages().ForEach(i => ImageCollection.Add((string)i.Tag, i));

			// Register standard types and imageKey
			TypeCollection.Register<Control>("Control");
			TypeCollection.Register<Form>("Form");
			TypeCollection.Register<RadioButton>("RadioButton");
			TypeCollection.Register<CheckBox>("CheckBox");
			TypeCollection.Register<ButtonBase>("Button");
			TypeCollection.Register<ComboBox>("ComboBox");
			TypeCollection.Register<ListBox>("ListBox");
			//TypeCollection.Register<ListControl>("ListControl");
			TypeCollection.Register<GroupBox>("GroupBox");
			TypeCollection.Register<TabPage>("TabPage");
			TypeCollection.Register<FlowLayoutPanel>("LayoutPanel");
			TypeCollection.Register<TableLayoutPanel>("LayoutPanel");
			TypeCollection.Register<Panel>("Panel");
			TypeCollection.Register<TabControl>("TabControl");
			TypeCollection.Register<TextBoxBase>("TextBox");
			//TypeCollection.Register<MaskedTextBox>("MaskedTextBox");
			//TypeCollection.Register<PasswordBox>("PasswordBox");
			TypeCollection.Register<Label>("Label");
			TypeCollection.Register<ProgressBar>("ProgressBar");
			TypeCollection.Register<DateTimePicker>("DateTimePicker");
			TypeCollection.Register<DataGrid>("DataGrid");
			TypeCollection.Register<UserControl>("UserControl");
			TypeCollection.Register<Splitter>("Splitter");
			TypeCollection.Register<ScrollableControl>("ScrollableControl");
		}
	}
}
