using System.Text;

namespace Core
{
	public class FoldBox : IDescriptor
	{
		public string GetDescription(object data)
		{
			var sb = new StringBuilder();
			sb.AppendLine("Step 5. Folding box.");
			sb.AppendLine("Cut out scraps and cut folds according to drawed lines.");
			sb.AppendLine();
			sb.AppendLine("Glue up the box using wall flap at the end.");
			sb.AppendLine();
			sb.AppendLine("Glue up the box bottom.");
			sb.AppendLine();
			sb.AppendLine("Insert object and glue up box top.");
			sb.AppendLine();
			sb.AppendLine("Congratulations. You can send a package.");
			return sb.ToString();
		}
	}
}