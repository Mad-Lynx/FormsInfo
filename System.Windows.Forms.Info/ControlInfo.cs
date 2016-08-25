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

		public Control SourceControl { get; }

		public Type Type { get; }

		public string ImageKey { get; }
	}
}