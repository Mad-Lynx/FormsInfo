using System.Collections.Generic;
using System.ComponentModel;

namespace System.Windows.Forms.Info.ComponentModel
{
	internal sealed class ReadonlyPropertyDescriptor : PropertyDescriptor
	{
		private readonly PropertyDescriptor property;

		public ReadonlyPropertyDescriptor(PropertyDescriptor descriptor, Attribute[] attrs)
			: base(descriptor, attrs)
		{
			property = descriptor;

			if (!Attributes.Contains(ReadOnlyAttribute.Yes))
			{
				var attributes = new List<Attribute>(AttributeArray)
					{
						ReadOnlyAttribute.Yes,
					};
				AttributeArray = attributes.ToArray();
			}
		}

		public ReadonlyPropertyDescriptor(PropertyDescriptor descriptor)
			: this(descriptor, null)
		{
		}

		public override Type ComponentType => property.ComponentType;

		public override bool IsReadOnly => true;

		public override Type PropertyType => property.PropertyType;

		public override string DisplayName => $"({base.DisplayName})";

		public override bool CanResetValue(object component)
		{
			return false;
		}

		public override object GetValue(object component)
		{
			return property.GetValue(component);
		}

		public override void ResetValue(object component)
		{
		}

		public override void SetValue(object component, object value)
		{
		}

		public override bool ShouldSerializeValue(object component)
		{
			return property.ShouldSerializeValue(component);
		}
	}
}