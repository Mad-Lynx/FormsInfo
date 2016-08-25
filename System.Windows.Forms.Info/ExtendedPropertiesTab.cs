using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms.Info.ComponentModel;
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

			var newProperties = new List<PropertyDescriptor>();

			var nameProperty = TypeDescriptor.GetProperties(component)["Name"];
			if (baseProperties["Name"] == null && nameProperty != null)
			{
				var descriptionAttribute = new DescriptionAttribute("The name of the control");
				newProperties.Add(new ReadonlyPropertyDescriptor(nameProperty, new Attribute[] { descriptionAttribute }));
			}

			// Do not add descriptor with Type to Type component :)
			if (context == null || context.PropertyDescriptor == null || context.PropertyDescriptor.PropertyType != typeof(Type))
			{
				TypeObjectConverter.Register();
				var descriptionAttribute = new DescriptionAttribute("The type of the object");
				newProperties.Add(new DelegatePropertyDescriptor<object, Type>("(Type)", c => c.GetType(), new Attribute[] { descriptionAttribute }));
			}

			return new PropertyDescriptorCollection(properties.Union(newProperties).ToArray());
		}
	}
}
