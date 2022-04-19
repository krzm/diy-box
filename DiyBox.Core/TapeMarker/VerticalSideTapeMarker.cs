namespace DiyBox.Core;

public class VerticalSideTapeMarker 
    : TapeMarker
{
    protected override ITapeMarker CalcMarks(
        IBoxCalculator bc)
    {
        var box = bc.SheetCalculator.Box;
        var waste = bc.Waste;
        if(bc.Waste.IsSideWaste == false)
        {
            Mark(box, waste);
        }
        else
        {
            MarkWithWaste(box, waste);
        }
        return this;
    }

    private void Mark(
        IBox box
        , IWaste waste)
    {
        Add("Fold1"
            , box.Side.Fold.Y);
        Add(
            "Wall"
            , "Fold1"
            , box.Side.Wall.Y);
        Add(
            "Fold2"
            , "Wall"
            , box.Side.Fold.Y);
    }

    private void MarkWithWaste(
        IBox box
        , IWaste waste)
    {
        Add("Waste1"
            , waste.WasteHeight);
        Add(
            "Fold1"
            , "Waste1"
            , box.Side.Fold.Y);
        Add(
            "Wall"
            , "Fold1"
            , box.Side.Wall.Y);
        Add(
            "Fold2"
            , "Wall"
            , box.Side.Fold.Y);
        Add(
            "Waste2"
            , "Fold2"
            , waste.WasteHeight);
    }
}