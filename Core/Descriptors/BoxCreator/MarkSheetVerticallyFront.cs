using System.Text;

namespace DiyBox.Core
{
	public class MarkSheetVerticallyFront : IDescriptor
	{
		public string GetDescription(object data)
		{
			var info = (BoxAndWaste)data;
			var sb = new StringBuilder();
			sb.AppendLine("Step 3.");
			if(info.Waste.IsFrontWaste)
			{
				sb.AppendLine($"Next go to top, left line and mark {info.Waste.WasteHeight} from top going down.");
				sb.AppendLine("Mark it with X as a waste.");
				sb.AppendLine($"Next mark at {info.Box.Front.Fold.Width} down.");
				sb.AppendLine($"Next mark at {info.Box.Front.Wall.Width} down.");
				sb.AppendLine($"Check if remaining length is {info.Box.Front.Fold.Width}.");
				sb.AppendLine($"Check down again, if remaining length is {info.Waste.WasteHeight}.");
				sb.AppendLine("Mark it with X as a waste.");
			}
			else
			{
				sb.AppendLine($"Next go to top, left line and mark {info.Box.Front.Fold.Width} from top going down.");
				sb.AppendLine($"Next mark at {info.Box.Front.Wall.Width} down.");
				sb.AppendLine($"Check if remaining length is {info.Box.Front.Fold.Width}.");
			}
			return sb.ToString();
		}
	}
}