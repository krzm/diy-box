using DiyBox.Core;
using Xunit;

namespace DiyBox.Tests;

public class SheetTests
{
	[Theory]
	[InlineData(2, 2, 2, 10)]
	public void Box_produces_sheet_Length(
		double length
		, double height
		, double depth
		, double sheetLength)
	{
		var box = new Box();
		var sut = new Sheet();

		sut.Calculate(box.Calculate(new Size3d(length, height, depth)));

		Assert.Equal(sheetLength, sut.Size.X);
	}

	[Theory]
	[InlineData(2, 2, 2, 4)]
	public void Box_produces_sheet_Heigth(
		double length
		, double height
		, double depth
		, double sheetHeigth)
	{
		var box = new Box();
		var sut = new Sheet();

		sut.Calculate(box.Calculate(new Size3d(length, height, depth)));

		Assert.Equal(sheetHeigth, sut.Size.Y);
	}
}