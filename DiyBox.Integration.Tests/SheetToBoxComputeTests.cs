using DiyBox.Core;
using Xunit;

namespace DiyBox.Integration.Tests;

public class SheetToBoxComputeTests
{
	[Theory]
	[InlineData(62, 25, 14, 11, 14)]
	public void SheetSizeConvertsToBox(
		double length
		, double height
        , double expectedX
        , double expectedY
        , double expectedZ)
	{
        var sut = new SheetToBoxCompute(
            new Size2dParser()
            , new BoxWithEvenFoldsCompute()
            , new SheetCompute());

        sut.Compute(new string[] 
        { 
            length.ToString()
            , height.ToString()
        } );

        ArgumentNullException.ThrowIfNull(sut.Box);
        ArgumentNullException.ThrowIfNull(sut.Box.Front);
        Assert.Equal(expectedX, sut.Box.Front.Wall.X);
        Assert.Equal(expectedY, sut.Box.Front.Wall.Y);
        ArgumentNullException.ThrowIfNull(sut.Box.Side);
        Assert.Equal(expectedZ, sut.Box.Side.Wall.X);
	}
}