namespace DiyBox.Core
{
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
			var frontHeight = box.Front.Fold.Width * 2 + box.Front.Wall.Width;
			var frontWaste = (sheet.Size.Width - frontHeight)/2;
			if (frontWaste > 0)
			{
				waste = frontWaste;
				isFrontWaste = true;
			}
			var sideHeight = box.Side.Fold.Width * 2 + box.Side.Wall.Width;
			var sideWaste = (sheet.Size.Width - sideHeight)/2;
			if (sideWaste > 0)
			{
				waste = sideWaste;
				isFrontWaste = false;
			}
		}
	}
}