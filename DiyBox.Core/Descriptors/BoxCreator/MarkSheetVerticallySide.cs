﻿using System.Text;

namespace DiyBox.Core;

public class MarkSheetVerticallySide 
	: IDescriptor
{
    private readonly ITapeMarker tapeMarker;

    public MarkSheetVerticallySide(
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
		sb.AppendLine("Step 4");
		sb.AppendLine("Move to next vertical line on the right");
		if (bc.Waste.IsFrontWaste == false)
		{
			sb.AppendLine($"From top going down, mark line on {bc.Waste.WasteHeight}");
			sb.AppendLine("Mark it with X as a waste");
			sb.AppendLine($"Next mark at {sc.Box.Side.Fold.Y} down");
			sb.AppendLine($"Next mark at {sc.Box.Side.Wall.Y} down");
			sb.AppendLine($"Check if remaining length is {sc.Box.Side.Fold.Y}");
			sb.AppendLine($"Check down again, if remaining length is {bc.Waste.WasteHeight}");
			sb.AppendLine("Mark it with X as a waste");
		}
		else
		{
			sb.AppendLine($"From top going dowan, mark line on {sc.Box.Side.Fold.Y}");
			sb.AppendLine($"(Measuring tape {tapeMarker.GetMark("box.Side.Fold.Y1")})");
			sb.AppendLine($"Next mark at {sc.Box.Side.Wall.Y} down");
			sb.AppendLine($"(Measuring tape {tapeMarker.GetMark("box.Side.Wall.Y")})");
			sb.AppendLine($"Check if remaining length is {sc.Box.Side.Fold.Y}");
			sb.AppendLine($"(Measuring tape {tapeMarker.GetMark("box.Side.Fold.Y2")})");
		}
		sb.AppendLine();
		sb.AppendLine("Repeat step 3 and 4 on two remaining vertical lines");
		sb.AppendLine();
		sb.AppendLine("Connect horizontally, markers you just did on vertical lines");
		return sb.ToString();
	}
}