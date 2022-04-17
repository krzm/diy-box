using System;

namespace DiyBox.Core;

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
		return (box.Front.Wall.X + box.Side.Wall.X) * 2 + box.WallFlap;
	}

	private double GetSheetHeight()
	{
		var frontHeight = box.Front.Wall.Y + 2 * box.Front.Fold.Y;
		var sideHeight = box.Side.Wall.Y + 2 * box.Side.Fold.Y;
		return Math.Max(frontHeight, sideHeight);
	}
}