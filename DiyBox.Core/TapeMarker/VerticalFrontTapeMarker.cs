using System.Collections.Generic;

namespace DiyBox.Core;

public class VerticalFrontTapeMarker 
    : ITapeMarker
{
    private readonly Box box;
    private Dictionary<string, double> marks;

    public VerticalFrontTapeMarker(Box box)
    {
        this.box = box;
        marks = new Dictionary<string, double>();
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
    }

    public double Mark(string markName)
    {
        return marks[markName];
    }
}