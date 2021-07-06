using System;

namespace Core
{
	public class Sheet
	{
		private readonly Box box;
		private readonly Size2d size;

		public Size2d Size => size;

		public Sheet(Box box)
		{
			this.box = box;
			size = new Size2d(
				GetSheetLength()
				, GetSheetHeight() );
		}

		private double GetSheetLength()
		{
			return (box.Front.Wall.Length + box.Side.Wall.Length) * 2 + box.WallFlap;
		}

		private double GetSheetHeight()
		{
			var frontHeight = box.Front.Wall.Height + 2 * box.Front.Fold.Height;
			var sideHeight = box.Side.Wall.Height + 2 * box.Side.Fold.Height;
			return Math.Max(frontHeight, sideHeight);
		}
	}
}