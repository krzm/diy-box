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
			if (Front.Wall.Length <= 5) return Front.Wall.Length;
			var flop = (int)(Front.Wall.Length / 4);
			return flop >= 5 ? (flop <= 10 ? flop : 10) : 5;
		}
	}
}