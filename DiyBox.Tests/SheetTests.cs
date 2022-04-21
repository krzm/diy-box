using DiyBox.Core;
using Moq;
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
		var mock = SetMock(length, height, depth);
		var sut = new Sheet();

		sut.Calculate(mock.Object);

		Assert.Equal(sheetLength, sut.Size.X);
	}

	private static Mock<IBox> SetMock(
		double length
		, double height
		, double depth)
    {
        var mock = new Mock<IBox>();
        var frontWall = new Size2d(length, height);
		var frontFold = new Size2d(length, height/2);
        var front = new BoxWall(frontWall, frontFold);
        mock.Setup(b => b.Front).Returns(front);
        var sideWall = new Size2d(depth, height);
		var sideFold = new Size2d(depth, length/2);
        var side = new BoxWall(sideWall, sideFold);
        mock.Setup(b => b.Side).Returns(side);
        mock.Setup(b => b.WallFlap).Returns(2);
        return mock;
    }

	[Theory]
	[InlineData(2, 2, 2, 4)]
	public void Box_produces_sheet_Heigth(
		double length
		, double height
		, double depth
		, double sheetHeigth)
	{
		var mock = SetMock(length, height, depth);
		var sut = new Sheet();

		sut.Calculate(mock.Object);

		Assert.Equal(sheetHeigth, sut.Size.Y);
	}
}