using System.Text;

namespace DiyBox.Core;

public class MarkSheetVerticallyFront
	: IDescriptor
{
    private readonly ITapeMarker tapeMarker;

    public MarkSheetVerticallyFront(
		ITapeMarker tapeMarker
	)
	{
        this.tapeMarker = tapeMarker;
    }

	public string GetDescription(object data)
	{
		var bc = (IBoxCalculator)data;
		var sc = bc.SheetCalculator; 
		var sb = new StringBuilder();
		sb.AppendLine("Step 3");
		if(bc.Waste.IsFrontWaste)
		{
			sb.AppendLine($"Next go to top, left line and mark {bc.Waste.WasteHeight} from top going down");
			sb.AppendLine("Mark it with X as a waste");
			sb.AppendLine($"Next mark at {sc.Box.Front.Fold.Y} down");
			sb.AppendLine($"Next mark at {sc.Box.Front.Wall.Y} down");
			sb.AppendLine($"Check if remaining length is {sc.Box.Front.Fold.Y}");
			sb.AppendLine($"Check down again, if remaining length is {bc.Waste.WasteHeight}");
			sb.AppendLine("Mark it with X as a waste");
		}
		else
		{
			sb.AppendLine($"Next go to top, left line and mark {sc.Box.Front.Fold.Y} from top going down");
			sb.AppendLine($"(Measuring tape {tapeMarker.GetMark("box.Front.Fold.Y1")})");
			sb.AppendLine($"Next mark at {sc.Box.Front.Wall.Y} down");
			sb.AppendLine($"(Measuring tape {tapeMarker.GetMark("box.Front.Wall.Y")})");
			sb.AppendLine($"Check if remaining length is {sc.Box.Front.Fold.Y}");
			sb.AppendLine($"(Measuring tape {tapeMarker.GetMark("sc.box.Front.Fold.Y2")})");
		}
		return sb.ToString();
	}
}