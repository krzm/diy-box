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
        Add("Step 2");
		Add("Box 2d layout");
		Add("Mark sheet horizontally");
		Add("Assumption2: sheet of cardborad");
		Add("is placed before you horizontally");
		Add("with it's length dimmention from left to right");
		Add("Mark top, from left to right, accros length of the sheet");
		Add("Mark line on {0}"
			, box.Front.Wall.X
			, "Front1");
		Add("next on {0}"
			, box.Side.Wall.X
			, "Side1");
		Add("Repeat those, once, to the end of the sheet");
		Add(""
			, box.Front.Wall.X
			, "Front2");
		Add(""
			, box.Side.Wall.X
			, "Side2");
		Add("Mark flap of length {0} at the end"
			, box.WallFlap
			, "WallFlap");
		Add("Add same markers at the bottom of the sheet");
		Add("Draw lines from top to botton through markers");
    }
}