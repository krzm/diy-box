using DiyBox.Core;
using Xunit;

namespace DiyBox.Tests;

public class VerticalSideTapeMarkerTests
{
	[Theory]
	[InlineData(20, 30, 10, 40, 50)]
	public void Convert_Vertical_Side_Points_To_Tape_Marks(
		double length
		, double heigth
		, double marker1
		, double marker2
		, double marker3)
	{
		var box = new Box();
		var sut = new VerticalSideTapeMarker();

		sut.Calculate(
			box.Calculate(
				new Size3d(
					length
					, heigth
					, 0.1)
			)
		);
		
		Assert.Equal(marker1, sut.GetMark("box.Side.Fold.Y1"));
		Assert.Equal(marker2, sut.GetMark("box.Side.Wall.Y"));
		Assert.Equal(marker3, sut.GetMark("box.Side.Fold.Y2"));
	}
}