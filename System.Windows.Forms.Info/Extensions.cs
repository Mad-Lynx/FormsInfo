using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace System.Windows.Forms.Info
{
	public static class Extensions
	{
		public static TreeNode Find(this TreeNodeCollection nodes, Predicate<TreeNode> predicate)
		{
			if (nodes == null)
				return null;

			foreach (TreeNode node in nodes)
			{
				if (predicate(node))
					return node;

				var subNode = node.Nodes.Find(predicate);
				if (subNode != null)
					return subNode;
			}

			return null;
		}

		public static void ForEach<TSource>(this IEnumerable<TSource> source, Action<TSource> predicate)
		{
			foreach (var element in source)
			{
				predicate(element);
			}
		}

		public static PropertyDescriptorCollection Filter(this PropertyDescriptorCollection properties, params string[] propertyNames)
		{
			var propertiesArray = properties.Cast<PropertyDescriptor>()
				.Where(pd => propertyNames.Contains(pd.Name))
				.ToArray();

			return new PropertyDescriptorCollection(propertiesArray, true);
		}
	}
}