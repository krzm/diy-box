using System.Text;

namespace DiyBox.Core;

public class PrepareSheet 
	: IDescriptor
{
	public string GetDescription(object data)
	{
		var sheet = (Sheet)data;
		var sb = new StringBuilder();
		sb.AppendLine($"Step 1");
		sb.AppendLine($"Prepare cardboard sheet");
		sb.AppendLine($"of length {sheet.Size.X} and heigth {sheet.Size.Y}");
		return sb.ToString();
	}
}