using System.Text;

namespace Core
{
	public class PrepareSheet : IDescriptor
	{
		public string GetDescription(object data)
		{
			var sheet = (Sheet)data;
			var sb = new StringBuilder();
			sb.AppendLine($"Step 1.");
			sb.AppendLine($"Please prepare cardboard sheet");
			sb.AppendLine($"of length {sheet.Size.Length} and heigth {sheet.Size.Height}");
			return sb.ToString();
		}
	}
}