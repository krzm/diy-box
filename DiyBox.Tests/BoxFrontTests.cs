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
		var sut = new Box();

		sut.Calculate(new Size3d(length, Unit, Unit));

		Assert.Equal(length, sut.Front.Wall.X);
	}

	[Theory]
	[InlineData(10)]
	public void Heigth_maps_to_box_front_wall_heigth(
		double heigth)
	{
		var sut = new Box();

		sut.Calculate(new Size3d(Unit, heigth, Unit));

		Assert.Equal(heigth, sut.Front.Wall.Y);
	}

	[Theory]
	[InlineData(10)]
	public void Length_maps_to_box_front_fold_length(
		double length)
	{
		var sut = new Box();

		sut.Calculate(new Size3d(length, Unit, Unit));

		Assert.Equal(length, sut.Front.Fold.X);
	}

	[Theory]
	[InlineData(10)]
	public void Width_maps_to_box_front_fold_heigth(
		double width)
	{
		var sut = new Box();

		sut.Calculate(new Size3d(Unit, width, Unit));

		Assert.Equal(width / 2, sut.Front.Fold.Y);
	}
}