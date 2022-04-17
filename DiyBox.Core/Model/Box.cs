namespace DiyBox.Core;

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
					size.X
					, size.Z)
				, new Size2d(
					size.X
					, size.Y/2));

		Side =
			new BoxWall(
				new Size2d(
					size.Y
					, size.Z)
				, new Size2d(
					size.Y
					, size.Y / 2));

		WallFlap = GetWallFlap();
	}

	private double GetWallFlap()
	{
		if (Front.Wall.X <= 5) return Front.Wall.X;
		var flop = (int)(Front.Wall.X / 4);
		return flop >= 5 ? (flop <= 10 ? flop : 10) : 5;
	}
}