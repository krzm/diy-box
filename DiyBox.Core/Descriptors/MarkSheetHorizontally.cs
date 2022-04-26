namespace DiyBox.Core;

public class MarkSheetHorizontally 
	: MarkerDescriptor<IBoxCalculator>
{
    public MarkSheetHorizontally(
		ITapeMarker tapeMarker
	) : base(tapeMarker)
	{
    }

    protected override void DefineDescription(
		IBoxCalculator bc)
    {
		var box = bc.SheetCalculator.Box;
        AddLine("Step 2");
		AddLine("Box 2d layout");
		AddLine("Mark sheet horizontally");
		AddLine("Assumption2: sheet of cardborad");
		AddLine("is placed before you horizontally");
		AddLine("with it's length dimmention from left to right");
		AddLine("Mark top, from left to right, accros length of the sheet");
		Add("Mark line on {0}"
			, box.Front.Wall.X
			, "Front1");
		Add("next on {0}"
			, box.Side.Wall.X
			, "Side1");
		AddLine("Repeat those, once, to the end of the sheet");
		Add(""
			, box.Front.Wall.X
			, "Front2");
		Add(""
			, box.Side.Wall.X
			, "Side2");
		Add("Mark flap of length {0} at the end"
			, box.WallFlap
			, "WallFlap");
		AddLine("Add same markers at the bottom of the sheet");
		AddLine("Draw lines from top to botton through markers");
    }
}