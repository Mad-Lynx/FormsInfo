using System.ComponentModel;
using System.Threading;

namespace System.Windows.Forms.Info.ComponentModel
{
	internal sealed class TypeObjectConverter : ExpandableObjectConverter
	{
		private static int isRegistered;

		public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext context, object value, Attribute[] attributes)
		{
			return base.GetProperties(context, value, attributes)
				.Filter(
					"Assembly",
					"Attributes",
					"BaseType",
					"DeclaringType",
					"FullName",
					"IsEnum",
					"IsGenericParameter",
					"IsGenericType",
					"Module",
					"Name");
		}

		public static void Register()
		{
			if (Interlocked.Exchange(ref isRegistered, 1) == 1)
				return;

			TypeDescriptor.AddAttributes(typeof(Type), new TypeConverterAttribute(typeof(TypeObjectConverter)));
		}
	}
}
