using System.Collections.Generic;

namespace DiyBox.Core;

public class VerticalSideTapeMarker 
    : ITapeMarker
{
    private readonly Box box;
    private Dictionary<string, double> marks;

    public VerticalSideTapeMarker(Box box)
    {
        this.box = box;
        marks = new Dictionary<string, double>();
        marks.Add(
            "box.Side.Fold.Y1"
            , box.Side.Fold.Y);
        marks.Add(
            "box.Side.Wall.Y"
            , marks["box.Side.Fold.Y1"] 
                + box.Side.Wall.Y);
        marks.Add(
            "box.Side.Fold.Y2"
            , marks["box.Side.Wall.Y"] 
                + box.Side.Fold.Y);
    }

    public double Mark(string markName)
    {
        return marks[markName];
    }
}