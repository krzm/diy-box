using DiyBox.Core;
using Xunit;

namespace DiyBox.Tests;

public class SheetComputeTests
    : ComputeTests
{
	[Theory]
	[InlineData(2, 2, 2, 10)]
	public void Box_produces_sheet_Length(
		double length
		, double height
		, double depth
		, double sheetLength)
	{
		var mock = SetBoxMock(
            new BoxMockData(length, height, depth, 2));
		var sut = new SheetCompute();

		sut.Compute(mock.Object);

		Assert.Equal(sheetLength, sut?.Size?.X);
	}

	[Theory]
	[InlineData(2, 2, 2, 4)]
	public void Box_produces_sheet_Heigth(
		double length
		, double height
		, double depth
		, double sheetHeigth)
	{
		var mock = SetBoxMock(
            new BoxMockData(length, height, depth, 2));
		var sut = new SheetCompute();

		sut.Compute(mock.Object);

		Assert.Equal(sheetHeigth, sut?.Size?.Y);
	}
}