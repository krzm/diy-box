using System;

namespace DiyBox.Core;

public class BoxCalcWithEvenFolds 
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

    protected override double GetFrontFoldHeigth(Size3d size) => 
        GetFoldHeigth(size);

    private static double GetFoldHeigth(Size3d size)
    {
        var frontFoldHeigth = size.Z / 2;
        var sideFoldHeigth = size.X / 2;
        var foldHeigth = Math.Min(
            frontFoldHeigth
            , sideFoldHeigth);
        return foldHeigth;
    }

    protected override double GetSideFoldHeigth(Size3d size) =>
        GetFoldHeigth(size);
}