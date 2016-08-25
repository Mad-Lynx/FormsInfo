using System.Drawing;

namespace System.Windows.Forms.Info
{
	public static class ImageCollection
	{
		internal static readonly ImageList ImageList = new ImageList();

		public static void Add(string key, Image image)
		{
			if (image != null)
				ImageList.Images.Add(key, image);
		}
	}
}
