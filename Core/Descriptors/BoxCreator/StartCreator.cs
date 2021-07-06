using System.Text;

namespace Core
{
	public class StartCreator : IDescriptor
	{
		public string GetDescription(object data)
		{
			var sb = new StringBuilder();
			sb.AppendLine($"You can now start step by step box creator.");
			return sb.ToString();
		}
	}
}