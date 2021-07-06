using System.Text;

namespace DiyBox.Core
{
	public class NextStep : IDescriptor
	{
		public string GetDescription(object data)
		{
			var sb = new StringBuilder();
			sb.AppendLine($"To move to next step push Enter.");
			return sb.ToString();
		}
	}
}