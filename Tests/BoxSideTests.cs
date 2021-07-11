using DiyBox.Core;
using Xunit;

namespace DiyBox.Tests
{
	public class BoxSideTests
	{
		private const double Unit = .1;

		[Theory]
		[InlineData(5)]
		public void Depth_produces_box_side_wall_width(
			double depth)
		{
			var sut = new Box(new Size3d(Unit, Unit, depth));

			Assert.Equal(depth, sut.Side.Wall.Length);
		}

		[Theory]
		[InlineData(10)]
		public void Height_produces_box_side_wall_heigth(
			double heigth)
		{
			var sut = new Box(new Size3d(Unit, heigth, Unit));

			Assert.Equal(heigth, sut.Side.Wall.Height);
		}

		[Theory]
		[InlineData(5)]
		public void Depth_produces_box_side_fold_width(
			double depth)
		{
			var sut = new Box(new Size3d(Unit, Unit, depth));

			Assert.Equal(depth, sut.Side.Fold.Length);
		}

		[Theory]
		[InlineData(20)]
		public void Length_produces_box_side_fold_heigth(
			double length)
		{
			var sut = new Box(new Size3d(length, Unit, Unit));

			Assert.Equal(length/2, sut.Side.Fold.Height);
		}
	}
}