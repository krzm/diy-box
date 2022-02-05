using DiyBox.Core;
using Xunit;

namespace DiyBox.Tests;

public class BoxSideTests
{
	private const double Unit = .1;

	[Theory]
	[InlineData(10)]
	public void Width_maps_to_box_side_wall_length(
		double width)
	{
		var sut = new Box(new Size3d(Unit, width, Unit));

		Assert.Equal(width, sut.Side.Wall.Length);
	}

	[Theory]
	[InlineData(10)]
	public void Height_maps_to_box_side_wall_width(
		double heigth)
	{
		var sut = new Box(new Size3d(Unit, Unit, heigth));

		Assert.Equal(heigth, sut.Side.Wall.Width);
	}

	[Theory]
	[InlineData(10)]
	public void Width_maps_to_box_side_fold_length(
		double width)
	{
		var sut = new Box(new Size3d(Unit, width, Unit));

		Assert.Equal(width, sut.Side.Fold.Length);
	}

	[Theory]
	[InlineData(10)]
	public void Width_maps_to_box_side_fold_width(
		double width)
	{
		var sut = new Box(new Size3d(Unit, width, Unit));

		Assert.Equal(width/2, sut.Side.Fold.Width);
	}
}