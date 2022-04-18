using System.Collections.Generic;

namespace DiyBox.Core;

public class HorizontalTapeMarker 
    : ITapeMarker
{
    private readonly Box box;
    private Dictionary<string, double> marks;

    public HorizontalTapeMarker(Box box)
    {
        this.box = box;
        marks = new Dictionary<string, double>();
        marks.Add(
            "box.Front.Wall.X1"
            , box.Front.Wall.X);
        marks.Add(
            "box.Side.Wall.X1"
            , marks["box.Front.Wall.X1"] 
                + box.Side.Wall.X);
        marks.Add(
            "box.Front.Wall.X2"
            , marks["box.Side.Wall.X1"] 
                + box.Front.Wall.X);
        marks.Add(
            "box.Side.Wall.X2"
            , marks["box.Front.Wall.X2"] 
                + box.Side.Wall.X);
        marks.Add(
            "box.WallFlap"
            , marks["box.Side.Wall.X2"] 
                + box.WallFlap);
    }

    public double Mark(string markName)
    {
        return marks[markName];
    }
}