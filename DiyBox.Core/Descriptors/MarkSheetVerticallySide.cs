namespace DiyBox.Core;

public class MarkSheetVerticallySide 
	: MarkerDescriptor<IDiyBoxCompute>
{
    public MarkSheetVerticallySide(
		ITapeMeasureCompute tapeMarker
	) : base(tapeMarker)
	{
    }
	
    protected override void DefineDescription(
		IDiyBoxCompute bc)
    {
        ArgumentNullException.ThrowIfNull(bc.SheetCalculator);
		var box = bc.SheetCalculator.Box;
		var waste = bc.Waste;
		AddLine("Step 4");
		AddLine("Move to next vertical line on the right (side wall)");
        ArgumentNullException.ThrowIfNull(waste);
        ArgumentNullException.ThrowIfNull(box);
		if(waste.IsSideWaste == false)
        {
            SetDescription(box);
        }
        else
        {
			SetDescriptionWithWaste(box, waste);
        }
		AddLine("Repeat step 3 and 4 on two remaining vertical lines");
		AddLine("Connect horizontally, markers you just did on vertical lines");
    }

    private void SetDescription(IBoxCompute box)
    {
        ArgumentNullException.ThrowIfNull(box.Side);
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
		IBoxCompute box
		, IWasteCompute waste)
    {
		Add("From top going down, mark line on {0}"
			, waste.WasteHeight
			, "Waste1");
		AddLine("Mark it with X as a waste");
        ArgumentNullException.ThrowIfNull(box.Side);
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
		AddLine("Mark it with X as a waste");
    }
}