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
			var frontHeight = box.Front.Fold.Height * 2 + box.Front.Wall.Height;
			var frontWaste = (sheet.Size.Height - frontHeight)/2;
			if (frontWaste > 0)
			{
				waste = frontWaste;
				isFrontWaste = true;
			}
			var sideHeight = box.Side.Fold.Height * 2 + box.Side.Wall.Height;
			var sideWaste = (sheet.Size.Height - sideHeight)/2;
			if (sideWaste > 0)
			{
				waste = sideWaste;
				isFrontWaste = false;
			}
		}
	}
}