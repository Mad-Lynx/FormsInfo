using System.Collections.Generic;
using System.Drawing;

namespace System.Windows.Forms.Info
{
	public class ImageCollection
	{
		internal readonly ImageList ImageList = new ImageList();
		private readonly Dictionary<Type, string> typeToImageKeyMap = new Dictionary<Type, string>();

		internal ImageCollection()
		{
		}

		public void RegisterImage(string key, Image image)
		{
			if (image == null)
				return;

			ImageList.Images.RemoveByKey(key);
			ImageList.Images.Add(key, image);
		}

		public void RegisterType<T>(string imageKey) where T : Control
		{
			if (!ImageList.Images.ContainsKey(imageKey))
				throw new KeyNotFoundException($"Key '{imageKey}' is not found in ImageList. Add image with this key first.");

			typeToImageKeyMap[typeof(T)] = imageKey;
		}

		public void RegisterType<T>(Image image) where T : Control
		{
			var imageKey = Guid.NewGuid().ToString();
			RegisterImage(imageKey, image);
			RegisterType<T>(imageKey);
		}

		public string GetImageKey(Type controlType)
		{
			do
			{
				string imageKey;
				if (typeToImageKeyMap.TryGetValue(controlType, out imageKey))
					return imageKey;

				controlType = controlType.BaseType;
			} while (controlType != null);

			// Just in case.
			return "Control";
		}
	}
}
