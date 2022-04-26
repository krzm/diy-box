namespace DiyBox.Core;

public class PrintOnSheet 
	: Descriptor<IBoxCalculator>
{
    private const string Arrow = "\\|/";

    protected override void DefineDescription(
		IBoxCalculator bc)
    {
        AddLine("Sheet: {0}-{1}"
            , bc.SheetCalculator.Sheet.Size.X
            , bc.SheetCalculator.Sheet.Size.Y);
        AddLine("Box: {0}-{1}-{2}"
            , bc.SheetCalculator.BoxSize.X
            , bc.SheetCalculator.BoxSize.Y
            , bc.SheetCalculator.BoxSize.Z);
        AddLine("-> {0}-{1}-{2}-{3}-{4}"
            , bc.HorizontalTapeMarker.GetMarks());
        if(bc.Waste.IsFrontWaste)
        {
            AddLine(GetMarksWithWaste()
                , bc.VerticalFrontTapeMarker.GetMarks());
        }
        else
        {
            AddLine(GetMarks()
                , bc.VerticalFrontTapeMarker.GetMarks());
        }
        if (bc.Waste.IsSideWaste)
        {
            AddLine(GetMarksWithWaste()
                , bc.VerticalSideTapeMarker.GetMarks());
        }
        else
        {
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