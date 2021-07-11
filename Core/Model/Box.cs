using System;

namespace DiyBox.Core
{
	public class Box
	{
		public BoxWall Front { get; private set; }

		public BoxWall Side { get; private set; }

		public double WallFlap { get; private set; }

		public Box(Size3d size)
		{
			Front =
				new BoxWall(
					new Size2d(
						size.Length
						, size.Height)
					, new Size2d(
						size.Length
						, size.Width/2));

			Side =
				new BoxWall(
					new Size2d(
						size.Width
						, size.Height)
					, new Size2d(
						size.Width
						, size.Length / 2));

			WallFlap = GetWallFlap();
		}

		private double GetWallFlap()
		{
			var max = Math.Max(
				Front.Wall.Length
				, Side.Wall.Length);
			int foldByPercent = (int)(max * 0.1);
			if (foldByPercent < 1) return 1;
			else return foldByPercent;
		}
	}
}