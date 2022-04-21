using DiyBox.Core;
using Xunit;

namespace DiyBox.Tests;

public class VerticalFrontTapeMarkerTests
    : TapeMarkerTests
{
	[Theory]
	[InlineData(30, 15, 45, 60)]
	public void Convert_Vertical_Front_Points_To_Tape_Marks(
		double heigth
		, double marker1
		, double marker2
		, double marker3)
	{
        var mock = SetBoxCalcMock(
            new BoxMockData(0.1, heigth, 0.1, 0.1)
            , new WasteMockData());
		var sut = new VerticalFrontTapeMarker();

		sut.Calculate(mock.Object);

		Assert.Equal(marker1, sut.GetMark("Fold1"));
		Assert.Equal(marker2, sut.GetMark("Wall"));
		Assert.Equal(marker3, sut.GetMark("Fold2"));
	}
}