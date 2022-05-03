using DiyBox.Core;
using Xunit;

namespace DiyBox.Tests;

public class VerticalSideTapeMeasureComputeTests
    : ComputeTests
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
		var mock = SetBoxCalcMock(
            new BoxMockData(length, heigth, 0.1, 0.1)
            , new WasteMockData());
		var sut = new VerticalSideTapeMeasureCompute();

		sut.Compute(mock.Object);
		
		Assert.Equal(marker1, sut.GetMark("Fold1"));
		Assert.Equal(marker2, sut.GetMark("Wall"));
		Assert.Equal(marker3, sut.GetMark("Fold2"));
	}
}