namespace DiyBox.Core;

public class Sheet 
	: ISheet
{
    private Size2d? size;

    public Size2d? Size => size;

    public ISheet Calculate(IBoxCalc box)
    {
        size = new Size2d(
            GetSheetLength(box)
            , GetSheetHeight(box));
        return this;
    }

    private double GetSheetLength(IBoxCalc box)
    {
        ArgumentNullException.ThrowIfNull(box.Front);
        ArgumentNullException.ThrowIfNull(box.Side);
        return 
            (box.Front.Wall.X + box.Side.Wall.X) * 2
            + box.WallFlap;
    }

    private double GetSheetHeight(IBoxCalc box)
    {
        ArgumentNullException.ThrowIfNull(box.Front);
        ArgumentNullException.ThrowIfNull(box.Side);
        var frontHeight = 
            box.Front.Wall.Y 
            + 2 * box.Front.Fold.Y;
        var sideHeight = 
            box.Side.Wall.Y 
            + 2 * box.Side.Fold.Y;
        return Math.Max(frontHeight, sideHeight);
    }
}