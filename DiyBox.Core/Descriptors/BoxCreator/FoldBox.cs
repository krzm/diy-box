using System.Text;

namespace DiyBox.Core;

public class FoldBox 
	: IDescriptor
{
	public string GetDescription(object data)
	{
		var sb = new StringBuilder();
		sb.AppendLine("Step 5");
		sb.AppendLine("Folding box");
		sb.AppendLine("Cut out waste marked with X id any");
		sb.AppendLine("Cut folds according to drawed lines");
		sb.AppendLine();
		sb.AppendLine("Glue up the box using wall flap at the end");
		sb.AppendLine();
		sb.AppendLine("Glue up the box bottom");
		sb.AppendLine();
		sb.AppendLine("Insert object and glue up box top");
		sb.AppendLine();
		sb.AppendLine("Congratulations ! You can send a package");
		return sb.ToString();
	}
}