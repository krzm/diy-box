namespace DiyBox.Core;

public class VerticalSideTapeMeasureCompute 
    : TapeMeasureCompute
{
    protected override ITapeMeasureCompute CalcMarks(
        object data)
    {
        var bc = (IDiyBoxCompute)data;
        var sc = bc.SheetCalculator;
        ArgumentNullException.ThrowIfNull(sc);
        var box = sc.Box;
        ArgumentNullException.ThrowIfNull(box);
        var waste = bc.Waste;
        ArgumentNullException.ThrowIfNull(waste);
        if(waste.IsSideWaste == false)
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
        IBoxCompute box
        , IWasteCompute waste)
    {
        ArgumentNullException.ThrowIfNull(box.Side);
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
        IBoxCompute box
        , IWasteCompute waste)
    {
        ArgumentNullException.ThrowIfNull(box.Side);
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