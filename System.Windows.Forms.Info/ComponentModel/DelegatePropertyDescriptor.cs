using System.ComponentModel;

namespace System.Windows.Forms.Info.ComponentModel
{
	internal sealed class DelegatePropertyDescriptor<TComponent, TProperty> : PropertyDescriptor
	{
		private readonly TProperty defaultValue;
		private readonly Func<TComponent, TProperty> getValue;
		private readonly Action<TComponent, TProperty> setValue;

		public DelegatePropertyDescriptor(
			string name,
			Func<TComponent, TProperty> getValue,
			Action<TComponent, TProperty> setValue,
			TProperty defaultValue,
			Attribute[] attrs)
			: base(name, attrs)
		{
			if (getValue == null)
				throw new ArgumentNullException(nameof(getValue));

			this.getValue = getValue;
			this.setValue = setValue;
			this.defaultValue = defaultValue;
		}

		public DelegatePropertyDescriptor(
			string name,
			Func<TComponent, TProperty> getValue,
			Action<TComponent, TProperty> setValue,
			TProperty defaultValue)
			: this(name, getValue, setValue, defaultValue, null)
		{
		}

		public DelegatePropertyDescriptor(
			string name,
			Func<TComponent, TProperty> getValue,
			Action<TComponent, TProperty> setValue)
			: this(name, getValue, setValue, default(TProperty))
		{
		}

		public DelegatePropertyDescriptor(string name, Func<TComponent, TProperty> getValue)
			: this(name, getValue, null, default(TProperty))
		{
		}

		public DelegatePropertyDescriptor(
			string name,
			Func<TComponent, TProperty> getValue,
			Action<TComponent, TProperty> setValue,
			Attribute[] attrs)
			: this(name, getValue, setValue, default(TProperty), attrs)
		{
		}

		public DelegatePropertyDescriptor(string name, Func<TComponent, TProperty> getValue, Attribute[] attrs)
			: this(name, getValue, null, attrs)
		{
		}

		public override bool IsReadOnly => setValue == null;

		public override Type ComponentType => typeof(TComponent);

		public override Type PropertyType => typeof(TProperty);

		public override bool CanResetValue(object component)
		{
			return !IsReadOnly && !Equals(getValue((TComponent) component), defaultValue);
		}

		public override object GetValue(object component)
		{
			return getValue((TComponent) component);
		}

		public override void ResetValue(object component)
		{
			setValue?.Invoke((TComponent) component, defaultValue);
		}

		public override void SetValue(object component, object value)
		{
			setValue?.Invoke((TComponent) component, (TProperty) value);
		}

		public override bool ShouldSerializeValue(object component)
		{
			return false;
		}
	}
}