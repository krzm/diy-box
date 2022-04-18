using System.Collections.Generic;

namespace DiyBox.Core;

public class VerticalFrontTapeMarker 
    : ITapeMarker
{
    private Dictionary<string, double> marks;

    public VerticalFrontTapeMarker()
    {
        marks = new Dictionary<string, double>();
    }

    public ITapeMarker Calculate(IBox box)
    {
        marks.Add(
            "box.Front.Fold.Y1"
            , box.Front.Fold.Y);
        marks.Add(
            "box.Front.Wall.Y"
            , marks["box.Front.Fold.Y1"] 
                + box.Front.Wall.Y);
        marks.Add(
            "box.Front.Fold.Y2"
            , marks["box.Front.Wall.Y"] 
                + box.Front.Fold.Y);
        return this;
    }

    public double GetMark(string markName)
    {
        return marks[markName];
    }
}