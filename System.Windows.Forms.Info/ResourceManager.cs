using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;

namespace System.Windows.Forms.Info
{
	internal static class ResourceManager
	{
		private static readonly Assembly ThisAssembly = Assembly.GetExecutingAssembly();

		public static Image GetImage(string name)
		{
			using (var stream = ThisAssembly.GetManifestResourceStream(typeof(ResourceManager), "Images." + name))
			{
				if (stream != null)
					return Image.FromStream(stream);
			}

			return null;
		}

		public static IEnumerable<Image> GetImages()
		{
			var startsWith = typeof(ResourceManager).Namespace + ".Images.";
			return ThisAssembly.GetManifestResourceNames()
				.Where(resourceName => resourceName.StartsWith(startsWith))
				.Select(resourceName => resourceName.Substring(startsWith.Length))
				.Select(imageName =>
					{
						var img = GetImage(imageName);
						img.Tag = imageName.Remove(imageName.LastIndexOf("."));
						return img;
					});
		}
	}
}
