using System.Collections.Generic;

namespace DiyBox.Core;

public class HorizontalTapeMarker 
    : ITapeMarker
{
    private Dictionary<string, double> marks;

    public HorizontalTapeMarker()
    {
        marks = new Dictionary<string, double>();
    }

    public ITapeMarker Calculate(IBoxCalculator bc)
    {
        var box = bc.SheetCalculator.Box;
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
        return this;
    }

    public double GetMark(string markName)
    {
        return marks[markName];
    }
}