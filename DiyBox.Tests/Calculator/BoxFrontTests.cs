using DiyBox.Core;
using Xunit;

namespace DiyBox.Tests;

public class BoxFrontTests
{
	private const double Unit = .1;

	[Theory]
	[InlineData(10)]
	public void Length_maps_to_box_front_wall_length(
		double length)
    {
        var size = new Size3d(length, Unit, Unit);
        var sut = new Box();

        sut.Calculate(size);

        Assert.Equal(length, sut.Front.Wall.X);
    }

    [Theory]
	[InlineData(10)]
	public void Heigth_maps_to_box_front_wall_heigth(
		double heigth)
	{
		var size = new Size3d(Unit, heigth, Unit);
		var sut = new Box();

		sut.Calculate(size);

		Assert.Equal(heigth, sut.Front.Wall.Y);
	}

	[Theory]
	[InlineData(10)]
	public void Length_maps_to_box_front_fold_length(
		double length)
	{
		var size = new Size3d(length, Unit, Unit);
		var sut = new Box();

		sut.Calculate(size);

		Assert.Equal(length, sut.Front.Fold.X);
	}

	[Theory]
	[InlineData(10)]
	public void Depth_maps_to_box_front_fold_heigth(
		double depth)
	{
		var size = new Size3d(Unit, Unit, depth);
		var sut = new Box();

		sut.Calculate(size);

		Assert.Equal(depth / 2, sut.Front.Fold.Y);
	}
}