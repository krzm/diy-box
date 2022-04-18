using System.Collections.Generic;

namespace DiyBox.Core;

public class VerticalSideTapeMarker 
    : ITapeMarker
{
    private Dictionary<string, double> marks;

    public VerticalSideTapeMarker()
    {
        marks = new Dictionary<string, double>();
    }

    public ITapeMarker Calculate(IBox box)
    {
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
        return this;
    }

    public double GetMark(string markName)
    {
        return marks[markName];
    }
}