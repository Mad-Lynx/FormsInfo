using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms.PropertyGridInternal;

namespace System.Windows.Forms.Info
{
	public class ExtendedPropertiesTab : PropertiesTab
	{
		public string Filter { get; set; }

		private Bitmap bitmap;

		public override Bitmap Bitmap
		{
			get
			{
				if (bitmap == null)
				{
					var type = typeof(PropertiesTab);
					bitmap = new Bitmap(type, type.Name + ".bmp");
				}
				return bitmap;
			}
		}

		public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext context, object component, Attribute[] attributes)
		{
			var baseProperties = base.GetProperties(context, component, attributes);
			var properties = baseProperties
				.Cast<PropertyDescriptor>()
				.Where(pd => String.IsNullOrEmpty(Filter) || pd.DisplayName.IndexOf(Filter, StringComparison.InvariantCultureIgnoreCase) >= 0);

			return new PropertyDescriptorCollection(properties.ToArray());
		}
	}
}
