using System.Text;

namespace DiyBox.Core;

public class MarkSheetHorizontally 
	: IDescriptor
{
	public string GetDescription(object data)
	{
		var box = (Box)data;
		var sb = new StringBuilder();
		sb.AppendLine($"Step 2");
		sb.AppendLine($"Box 2d layout");
		sb.AppendLine($"Mark sheet horizontally");
		sb.AppendLine("Assumption2: sheet of cardborad");
		sb.AppendLine("is placed before you horizontally");
		sb.AppendLine("with it's length dimmention from left to right");
		sb.AppendLine();
		sb.AppendLine("Mark top, from left to right, accros length of the sheet");
		sb.AppendLine($"Mark line on {box.Front.Wall.X}");
		sb.AppendLine($"next on {box.Side.Wall.X}.");
		sb.AppendLine();
		sb.AppendLine($"Repeat those, once, to the end of the sheet");
		sb.AppendLine();
		sb.AppendLine($"Mark flap of length {box.WallFlap} at the end");
		sb.AppendLine();
		sb.AppendLine("Add same markers at the bottom of the sheet");
		sb.AppendLine();
		sb.AppendLine("Draw lines from top to botton through markers");
		return sb.ToString();
	}
}