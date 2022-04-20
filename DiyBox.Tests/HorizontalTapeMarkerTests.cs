using DiyBox.Core;
using Moq;
using Xunit;

namespace DiyBox.Tests;

public class HorizontalTapeMarkerTests
{
	[Theory]
	[InlineData(20, 10, 20, 30, 50, 60, 65)]
	public void Convert_Horizontal_Points_To_Tape_Marks(
		double length
		, double depth
		, double marker1
		, double marker2
		, double marker3
		, double marker4
		, double marker5)
	{
		var mock = new Mock<IBox>();
		var frontWall = new Size2d(length, 0.1);
		var front = new BoxWall(frontWall, null);
		mock.Setup(b => b.Front).Returns(front);
		var sideWall = new Size2d(depth, 0.1);
		var side = new BoxWall(sideWall, null);
		mock.Setup(b => b.Side).Returns(side);
		mock.Setup(b => b.WallFlap).Returns(5);
		var sut = new HorizontalTapeMarker();
		
		sut.Calculate(mock.Object);
		
		Assert.Equal(marker1, sut.GetMark("Front1"));
		Assert.Equal(marker2, sut.GetMark("Side1"));
		Assert.Equal(marker3, sut.GetMark("Front2"));
		Assert.Equal(marker4, sut.GetMark("Side2"));
		Assert.Equal(marker5, sut.GetMark("WallFlap"));
	}
}