namespace DiyBox.Core;

public class Waste
{
	private readonly double waste;
	private readonly bool isFrontWaste;

	public double WasteHeight => waste;
	
	public bool IsFrontWaste => isFrontWaste;

	public Waste(
		Box box
		, Sheet sheet)
	{
		var frontHeight = box.Front.Fold.Y * 2 + box.Front.Wall.Y;
		var frontWaste = (sheet.Size.Y - frontHeight)/2;
		if (frontWaste > 0)
		{
			waste = frontWaste;
			isFrontWaste = true;
		}
		var sideHeight = box.Side.Fold.Y * 2 + box.Side.Wall.Y;
		var sideWaste = (sheet.Size.Y - sideHeight)/2;
		if (sideWaste > 0)
		{
			waste = sideWaste;
			isFrontWaste = false;
		}
	}
}