namespace DiyBox.Core;

public class Box 
	: IBox
{
    public BoxWall Front { get; private set; }

    public BoxWall Side { get; private set; }

    public double WallFlap { get; private set; }

    public IBox Calculate(Size3d size)
    {
        Front =
            new BoxWall(
                new Size2d(
                    size.X
                    , size.Y)
                , new Size2d(
                    size.X
                    , size.Z / 2));

        Side =
            new BoxWall(
                new Size2d(
                    size.Z
                    , size.Y)
                , new Size2d(
                    size.Z
                    , size.X / 2));

        WallFlap = GetWallFlap();

        return this;
    }

    private double GetWallFlap()
    {
        if (Front.Wall.X <= 5)
            return Front.Wall.X;
        var flop = (int)(Front.Wall.X / 4);
        return flop >= 5 ?
            (flop <= 10 ? flop : 10)
            : 5;
    }
}