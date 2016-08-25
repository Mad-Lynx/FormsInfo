namespace System.Windows.Forms.Info
{
	internal class ControlInfo
	{
		public ControlInfo(Control sourceControl)
		{
			SourceControl = sourceControl;
			Type = sourceControl.GetType();
			ImageKey = TypeCollection.GetImageKey(Type);
		}

		public Control SourceControl { get; private set; }

		public Type Type { get; private set; }

		public string ImageKey { get; private set; }
	}
}