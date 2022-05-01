using System;

namespace DiyBox.Core;

public class VerticalFrontTapeMarker 
    : TapeMarker
{
    protected override ITapeMarker CalcMarks(
        object data)
    {
        var bc = (IBoxCalculator)data;
        var sc = bc.SheetCalculator;
        ArgumentNullException.ThrowIfNull(sc);
        var box = sc.Box;
        ArgumentNullException.ThrowIfNull(box);
        var waste = bc.Waste;
        ArgumentNullException.ThrowIfNull(waste);
        if(waste.IsFrontWaste == false)
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
        IBoxCalc box
		, IWaste waste)
    {
        ArgumentNullException.ThrowIfNull(box.Front);
        Add("Fold1"
            , box.Front.Fold.Y);
        Add(
            "Wall"
            , "Fold1"
            , box.Front.Wall.Y);
        Add(
            "Fold2"
            , "Wall"
            , box.Front.Fold.Y);
    }

    private void MarkWithWaste(
        IBoxCalc box
		, IWaste waste)
    {
        ArgumentNullException.ThrowIfNull(box.Front);
        Add("Waste1"
            , waste.WasteHeight);
        Add(
            "Fold1"
            , "Waste1"
            , box.Front.Fold.Y);
        Add(
            "Wall"
            , "Fold1"
            , box.Front.Wall.Y);
        Add(
            "Fold2"
            , "Wall"
            , box.Front.Fold.Y);
        Add(
            "Waste2"
            , "Fold2"
            , waste.WasteHeight);
    }
}