namespace DiyBox.Core;

public class PrintOnSheet 
	: Descriptor<IBoxCalculator>
{
    protected override void DefineDescription(
		IBoxCalculator bc)
    {
        Add("Sheet: {0}x{1}"
            , bc.SheetCalculator.Sheet.Size.X
            , bc.SheetCalculator.Sheet.Size.Y);
        Add("Box front: X {0}, Y {1}, box depth: Z {2}"
            , bc.SheetCalculator.BoxSize.X
            , bc.SheetCalculator.BoxSize.Y
            , bc.SheetCalculator.BoxSize.Z);
        Add("Horizontal marking: {0}"
            , string.Join('-', bc.HorizontalTapeMarker.GetMarks()));
        Add("Vertical first and third line marking: {0}"
            , string.Join('-', bc.VerticalFrontTapeMarker.GetMarks()));
        Add("Vertical second and fourth line marking: {0}"
            , string.Join('-', bc.VerticalSideTapeMarker.GetMarks()));
    }
}