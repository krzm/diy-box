using DiyBox.Core;
using Xunit;

namespace DiyBox.Tests;

public class VerticalFrontTapeMarkerTests
{
	[Theory]
	[InlineData(30, 15, 45, 60)]
	public void Convert_Vertical_Front_Points_To_Tape_Marks(
		double heigth
		, double marker1
		, double marker2
		, double marker3)
	{
		var box = new Box();
		var sut = new VerticalFrontTapeMarker();
		
		sut.Calculate(
			box.Calculate(
				new Size3d(
					0.1
					, heigth
					, 0.1)
			)
		);

		Assert.Equal(marker1, sut.GetMark("box.Front.Fold.Y1"));
		Assert.Equal(marker2, sut.GetMark("box.Front.Wall.Y"));
		Assert.Equal(marker3, sut.GetMark("box.Front.Fold.Y2"));
	}
}