namespace DiyBox.Core;

public abstract class BoxComputeBase
    : IBoxCompute
{
    public BoxWall? Front { get; protected set; }
    public BoxWall? Side { get; protected set; }
    public double WallFlap { get; protected set; }

    public IBoxCompute Compute(Size3d size)
    {
        SetFront(size);
        SetSide(size);
        SetFlap(size);
        return this;
    }

    protected abstract void SetFront(Size3d size);
    protected abstract void SetSide(Size3d size);
    protected virtual void SetFlap(Size3d size)
    {
        ArgumentNullException.ThrowIfNull(Front);
        if (Front.Wall.X <= 5)
            WallFlap = Front.Wall.X;
        var flop = (int)(Front.Wall.X / 4);
        WallFlap = flop >= 5 ?
            (flop <= 10 ? flop : 10)
            : 5;
    }

    protected abstract double GetFrontFoldHeigth(
        Size3d size);
    
    protected abstract double GetSideFoldHeigth(
        Size3d size);
}