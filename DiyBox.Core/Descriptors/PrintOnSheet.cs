using System;

namespace DiyBox.Core;

public class PrintOnSheet 
	: Descriptor<IBoxCalculator>
{
    private const string Arrow = "\\|/";

    protected override void DefineDescription(
		IBoxCalculator bc)
    {
        ArgumentNullException.ThrowIfNull(bc.SheetCalculator);
        ArgumentNullException.ThrowIfNull(bc.SheetCalculator.Sheet);
        ArgumentNullException.ThrowIfNull(bc.SheetCalculator.Sheet.Size);
        AddLine("Sheet: {0}-{1}"
            , bc.SheetCalculator.Sheet.Size.X
            , bc.SheetCalculator.Sheet.Size.Y);
        ArgumentNullException.ThrowIfNull(bc.SheetCalculator.BoxSize);
        AddLine("Box: {0}-{1}-{2}"
            , bc.SheetCalculator.BoxSize.X
            , bc.SheetCalculator.BoxSize.Y
            , bc.SheetCalculator.BoxSize.Z);
        ArgumentNullException.ThrowIfNull(bc.HorizontalTapeMarker);
        AddLine("-> {0}-{1}-{2}-{3}-{4}"
            , bc.HorizontalTapeMarker.GetMarks());
        ArgumentNullException.ThrowIfNull(bc.Waste);
        if(bc.Waste.IsFrontWaste)
        {
            ArgumentNullException.ThrowIfNull(bc.VerticalFrontTapeMarker);
            AddLine(GetMarksWithWaste()
                , bc.VerticalFrontTapeMarker.GetMarks());
        }
        else
        {
            ArgumentNullException.ThrowIfNull(bc.VerticalFrontTapeMarker);
            AddLine(GetMarks()
                , bc.VerticalFrontTapeMarker.GetMarks());
        }
        if (bc.Waste.IsSideWaste)
        {
            ArgumentNullException.ThrowIfNull(bc.VerticalSideTapeMarker);
            AddLine(GetMarksWithWaste()
                , bc.VerticalSideTapeMarker.GetMarks());
        }
        else
        {
            ArgumentNullException.ThrowIfNull(bc.VerticalSideTapeMarker);
            AddLine(GetMarks()
                , bc.VerticalSideTapeMarker.GetMarks());
        }
    }

    private static string GetMarksWithWaste()
    {
        return string.Join(" ", Arrow, "{0}x-{1}-{2}-{3}-x{4}");
    }

    private static string GetMarks()
    {
        return string.Join(" ", Arrow, "{0}-{1}-{2}");
    }
}