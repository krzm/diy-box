using System.Text;

namespace DiyBox.Core
{
	public class MarkSheetVerticallySide : IDescriptor
	{
		public string GetDescription(object data)
		{
			var info = (BoxAndWaste)data;
			var sb = new StringBuilder();
			sb.AppendLine("Step 4.");
			sb.AppendLine("Move to next vertical line on the right.");
			if (!info.Waste.IsFrontWaste)
			{
				sb.AppendLine($"From top going down, mark line on {info.Waste.WasteHeight}.");
				sb.AppendLine("Mark it with X as a waste.");
				sb.AppendLine($"Next mark at {info.Box.Side.Fold.Y} down.");
				sb.AppendLine($"Next mark at {info.Box.Side.Wall.Y} down.");
				sb.AppendLine($"Check if remaining length is {info.Box.Side.Fold.Y}.");
				sb.AppendLine($"Check down again, if remaining length is {info.Waste.WasteHeight}.");
				sb.AppendLine("Mark it with X as a waste.");
			}
			else
			{
				sb.AppendLine($"From top going dowan, mark line on {info.Box.Side.Fold.Y}.");
				sb.AppendLine($"Next mark at {info.Box.Side.Wall.Y} down.");
				sb.AppendLine($"Check if remaining length is {info.Box.Side.Fold.Y}.");
			}
			sb.AppendLine();
			sb.AppendLine("Repeat step 3 and 4 on two remaining vertical lines.");
			sb.AppendLine();
			sb.AppendLine("Connect horizontally markers you just did on vertical lines.");
			return sb.ToString();
		}
	}
}