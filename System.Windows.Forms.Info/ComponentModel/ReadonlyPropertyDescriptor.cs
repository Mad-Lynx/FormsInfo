using System.Collections.Generic;
using System.ComponentModel;

namespace System.Windows.Forms.Info.ComponentModel
{
	internal sealed class ReadonlyPropertyDescriptor : PropertyDescriptor
	{
		private readonly PropertyDescriptor property;

		public override Type ComponentType
		{
			get
			{
				return property.ComponentType;
			}
		}

		public override bool IsReadOnly
		{
			get
			{
				return true;
			}
		}

		public override Type PropertyType
		{
			get
			{
				return property.PropertyType;
			}
		}

		public override string DisplayName
		{
			get
			{
				return String.Format("({0})", base.DisplayName);
			}
		}

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
