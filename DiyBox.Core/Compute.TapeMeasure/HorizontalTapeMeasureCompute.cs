namespace DiyBox.Core;

public class HorizontalTapeMeasureCompute 
    : TapeMeasureCompute
{
    protected override ITapeMeasureCompute CalcMarks(
        object data)
    {
        var box = (IBoxCompute)data;
        ArgumentNullException.ThrowIfNull(box.Front);
        ArgumentNullException.ThrowIfNull(box.Side);
        Add(
            "Front1"
            , box.Front.Wall.X);
        Add(
            "Side1"
            , "Front1" 
            , box.Side.Wall.X);
        Add(
            "Front2"
            , "Side1" 
            , box.Front.Wall.X);
        Add(
            "Side2"
            , "Front2" 
            , box.Side.Wall.X);
        Add(
            "WallFlap"
            , "Side2" 
            , box.WallFlap);
        return this;
    }
}