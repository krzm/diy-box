using DiyBox.Core;
using Xunit;

namespace DiyBox.Tests;

public class BoxSideTests
{
	private const double Unit = .1;

	[Theory]
	[InlineData(10)]
	public void Heigth_maps_to_box_side_wall_heigth(
		double heigth)
	{
		var sut = new Box();

		sut.Calculate(new Size3d(Unit, heigth, Unit));

		Assert.Equal(heigth, sut.Side.Wall.Y);
	}

	[Theory]
	[InlineData(10)]
	public void Depth_maps_to_box_side_wall_length(
		double depth)
	{
		var sut = new Box();

		sut.Calculate(new Size3d(Unit, Unit, depth));

		Assert.Equal(depth, sut.Side.Wall.X);
	}

	[Theory]
	[InlineData(10)]
	public void Depth_maps_to_box_side_fold_length(
		double depth)
	{
		var sut = new Box();

		sut.Calculate(new Size3d(Unit, Unit, depth));

		Assert.Equal(depth, sut.Side.Fold.X);
	}

	[Theory]
	[InlineData(10)]
	public void Length_maps_to_box_side_fold_heigth(
		double length)
	{
		var sut = new Box();

		sut.Calculate(new Size3d(length, Unit, Unit));

		Assert.Equal(length/2, sut.Side.Fold.Y);
	}
}