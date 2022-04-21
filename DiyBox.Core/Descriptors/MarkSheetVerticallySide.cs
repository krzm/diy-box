﻿namespace DiyBox.Core;

public class MarkSheetVerticallySide 
	: MarkerDescriptor<IBoxCalculator>
{
    public MarkSheetVerticallySide(
		ITapeMarker tapeMarker
	) : base(tapeMarker)
	{
    }
	
    protected override void DefineDescription(
		IBoxCalculator bc)
    {
		var box = bc.SheetCalculator.Box;
		var waste = bc.Waste;
		Add("Step 4");
		Add("Move to next vertical line on the right (side wall)");
		if(waste.IsSideWaste == false)
        {
            SetDescription(box);
        }
        else
        {
			SetDescriptionWithWaste(box, waste);
        }
		Add("Repeat step 3 and 4 on two remaining vertical lines");
		Add("Connect horizontally, markers you just did on vertical lines");
    }

    private void SetDescription(IBox box)
    {
		Add("From top going dowan, mark line on {0}"
			, box.Side.Fold.Y
			, "Fold1");
		Add("Next mark at {0} down"
			, box.Side.Wall.Y
			, "Wall");
		Add("Check if remaining length is {0}"
			, box.Side.Fold.Y
			, "Fold2");
    }

	private void SetDescriptionWithWaste(
		IBox box
		, IWaste waste)
    {
		Add("From top going down, mark line on {0}"
			, waste.WasteHeight
			, "Waste1");
		Add("Mark it with X as a waste");
		Add("Next mark at {0} down"
			, box.Side.Fold.Y
			, "Fold1");
		Add("Next mark at {0} down"
			, box.Side.Wall.Y
			, "Wall");
		Add("Check if remaining length is {0}"
			, box.Side.Fold.Y
			, "Fold2");
		Add("Check down again, if remaining length is {0}"
			, waste.WasteHeight
			, "Waste2");
		Add("Mark it with X as a waste");
    }
}