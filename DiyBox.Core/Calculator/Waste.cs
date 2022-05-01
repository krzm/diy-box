namespace DiyBox.Core;

public class Waste 
	: IWaste
{
    private double waste;
    private bool isFrontWaste;
    private bool isSideWaste;

    public double WasteHeight => waste;

    public bool IsFrontWaste => isFrontWaste;
    public bool IsSideWaste => isSideWaste;

    public IWaste Calculate(ISheetCalculator c)
    {
        Reset();
        CalcFrontWaste(c);
        CalcSideWaste(c);
        return this;
    }

    private void Reset()
    {
        isFrontWaste = false;
        isSideWaste = false;
        waste = 0.0;
    }

    private void CalcFrontWaste(ISheetCalculator c)
    {   
        ArgumentNullException.ThrowIfNull(c.Box);
        ArgumentNullException.ThrowIfNull(c.Box.Front);
        var frontHeight =
            c.Box.Front.Fold.Y * 2
            + c.Box.Front.Wall.Y;
        ArgumentNullException.ThrowIfNull(c.Sheet);
        ArgumentNullException.ThrowIfNull(c.Sheet.Size);
        var frontWaste =
            (c.Sheet.Size.Y - frontHeight) / 2;
        if (frontWaste > 0)
        {
            waste = frontWaste;
            isFrontWaste = true;
        }
    }

    private void CalcSideWaste(ISheetCalculator c)
    {
        ArgumentNullException.ThrowIfNull(c.Box);
        ArgumentNullException.ThrowIfNull(c.Box.Side);
        var sideHeight =
            c.Box.Side.Fold.Y * 2
            + c.Box.Side.Wall.Y;
        ArgumentNullException.ThrowIfNull(c.Sheet);
        ArgumentNullException.ThrowIfNull(c.Sheet.Size);
        var sideWaste =
            (c.Sheet.Size.Y - sideHeight) / 2;
        if (sideWaste > 0)
        {
            waste = sideWaste;
            isSideWaste = true;
        }
    }
}