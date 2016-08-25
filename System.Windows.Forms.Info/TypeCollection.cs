using System.Collections.Generic;
using System.Drawing;

namespace System.Windows.Forms.Info
{
	public static class TypeCollection
	{
		private static readonly Dictionary<Type, string> Types = new Dictionary<Type, string>();

		public static void Register<T>(string imageKey) where T : Control
		{
			Types[typeof(T)] = imageKey;
		}

		public static void Register<T>(Image image) where T : Control
		{
			var imageKey = Guid.NewGuid().ToString();
			ImageCollection.Add(imageKey, image);
			Register<T>(imageKey);
		}


		public static string GetImageKey(Type controlType)
		{
			do
			{
				string imageKey;
				if (Types.TryGetValue(controlType, out imageKey))
					return imageKey;

				controlType = controlType.BaseType;
			} while (controlType != null);

			// Just in case.
			return "Control";
		}
	}
}
