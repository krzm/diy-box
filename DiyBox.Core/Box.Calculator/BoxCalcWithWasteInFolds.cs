namespace DiyBox.Core;

public class BoxCalcWithWasteInFolds 
	: BoxCalcBase
{
    protected override void SetFront(Size3d size)
    {
        Front =
            new BoxWall(
                new Size2d(
                    size.X
                    , size.Y)
                , new Size2d(
                    size.X
                    , GetFrontFoldHeigth(size)));
    }

    protected override void SetSide(Size3d size)
    {
        Side =
            new BoxWall(
                new Size2d(
                    size.Z
                    , size.Y)
                , new Size2d(
                    size.Z
                    , GetSideFoldHeigth(size)));
    }

    protected override double GetFrontFoldHeigth(Size3d size)
    {
        return size.Z / 2;
    }

    protected override double GetSideFoldHeigth(Size3d size)
    {
        return size.X / 2;
    }
}