namespace DiyBox.Core;

public class HorizontalTapeMarker 
    : TapeMarker
{
    public override ITapeMarker Calculate(IBoxCalculator bc)
    {
        var box = bc.SheetCalculator.Box;
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