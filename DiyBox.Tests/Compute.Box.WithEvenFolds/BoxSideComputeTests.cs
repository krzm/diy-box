using DiyBox.Core;
using Xunit;

namespace DiyBox.Tests.WithEvenFolds;

public class BoxSideComputeTests
    : BoxComputeTests
{
	private const double Unit = .1;

	[Theory]
	[InlineData(10)]
	public void Heigth_maps_to_box_side_wall_heigth(
		double heigth)
	{
		var size = new Size3d(Unit, heigth, Unit);
		var sut = GetSut();

		sut.Compute(size);

		Assert.Equal(heigth, sut?.Side?.Wall.Y);
	}

	[Theory]
	[InlineData(10)]
	public void Depth_maps_to_box_side_wall_length(
		double depth)
	{
		var size = new Size3d(Unit, Unit, depth);
		var sut = GetSut();

		sut.Compute(size);

		Assert.Equal(depth, sut?.Side?.Wall.X);
	}

	[Theory]
	[InlineData(10)]
	public void Depth_maps_to_box_side_fold_length(
		double depth)
	{
		var size = new Size3d(Unit, Unit, depth);
		var sut = GetSut();

		sut.Compute(size);

		Assert.Equal(depth, sut?.Side?.Fold.X);
	}

	[Theory]
	[InlineData(10, 10)]
    [InlineData(20, 10)]
    [InlineData(10, 20)]
	public void Length_maps_to_box_side_fold_heigth(
		double length
        , double depth)
	{
		var size = new Size3d(length, Unit, depth);
		var sut = GetSut();

		sut.Compute(size);

		Assert.Equal(GetExpectedSideFoldHeigth(size)
            , sut?.Side?.Fold.Y);
	}
}