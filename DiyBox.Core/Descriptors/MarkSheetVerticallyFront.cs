namespace DiyBox.Core;

public class MarkSheetVerticallyFront
	: MarkerDescriptor<IBoxCalculator>
{
    public MarkSheetVerticallyFront(
		ITapeMarker tapeMarker
	) : base(tapeMarker)
	{
    }

    protected override void DefineDescription(
		IBoxCalculator bc)
    {
        var box = bc.SheetCalculator.Box;
        var waste = bc.Waste;
        AddLine("Step 3");
		AddLine("Mark vertically, front and back walls");
		if(waste.IsFrontWaste == false)
        {
            SetDescription(box);
        }
        else
        {
            SetDescriptionWithWaste(box, waste);
        }
    }

    private void SetDescription(IBox box)
    {
		Add("Next go to top, left line and mark {0} from top going down"
			, box.Front.Fold.Y
			, "Fold1");
        Add("Next mark at {0} down"
            , box.Front.Wall.Y
            , "Wall");
        Add("Check if remaining length is {0}"
            , box.Front.Fold.Y
            , "Fold2");
    }

    private void SetDescriptionWithWaste(IBox box, IWaste waste)
    {
        Add("Next go to top, left line and mark {0} from top going down"
			, waste.WasteHeight
			, "Waste1");
        AddLine("Mark it with X as a waste");
        Add("Next mark at {0} down"
            , box.Front.Fold.Y
            , "Fold1");
        Add("Next mark at {0} down"
            , box.Front.Wall.Y
            , "Wall");
        Add("Check if remaining length is {0}"
            , box.Front.Fold.Y
            , "Fold2");
        Add("Check down again, if remaining length is {0}"
            , waste.WasteHeight
            , "Waste2");
        AddLine("Mark it with X as a waste");
    }
}