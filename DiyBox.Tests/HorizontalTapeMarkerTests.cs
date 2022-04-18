using DiyBox.Core;
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
		var box = new Box();
		var sut = new HorizontalTapeMarker();

		sut.Calculate(
			box.Calculate(
				new Size3d(
					length
					, 0.1
					, depth)));
		
		Assert.Equal(marker1, sut.GetMark("box.Front.Wall.X1"));
		Assert.Equal(marker2, sut.GetMark("box.Side.Wall.X1"));
		Assert.Equal(marker3, sut.GetMark("box.Front.Wall.X2"));
		Assert.Equal(marker4, sut.GetMark("box.Side.Wall.X2"));
		Assert.Equal(marker5, sut.GetMark("box.WallFlap"));
	}
}