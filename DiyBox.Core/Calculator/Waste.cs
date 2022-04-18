namespace DiyBox.Core;

public class Waste 
	: IWaste
{
    private double waste;
    private bool isFrontWaste;

    public double WasteHeight => waste;

    public bool IsFrontWaste => isFrontWaste;

    public IWaste Calculate(ISheetCalculator c)
    {
        var frontHeight = 
			c.Box.Front.Fold.Y * 2 
			+ c.Box.Front.Wall.Y;
        var frontWaste = 
			(c.Sheet.Size.Y - frontHeight) / 2;
        if (frontWaste > 0)
        {
            waste = frontWaste;
            isFrontWaste = true;
        }
        var sideHeight = 
			c.Box.Side.Fold.Y * 2 
			+ c.Box.Side.Wall.Y;
        var sideWaste = 
			(c.Sheet.Size.Y - sideHeight) / 2;
        if (sideWaste > 0)
        {
            waste = sideWaste;
            isFrontWaste = false;
        }
		return this;
    }
}