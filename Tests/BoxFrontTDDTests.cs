using DiyBox.Core;
using Xunit;

namespace DiyBox.Tests
{
	public class BoxFrontTDDTests
	{
		private const double Unit = .1;

		[Theory]
		[InlineData(20)]
		public void Length_produces_box_front_wall_width(
			double length)
		{
			var sut = new Box(new Size3d(length, Unit, Unit));

			Assert.Equal(length, sut.Front.Wall.Length);
		}

		[Theory]
		[InlineData(10)]
		public void Height_produces_box_front_wall_heigth(
			double heigth)
		{
			var sut = new Box(new Size3d(Unit, heigth, Unit));

			Assert.Equal(heigth, sut.Front.Wall.Height);
		}

		[Theory]
		[InlineData(20)]
		public void Length_produces_box_front_fold_width(
			double length)
		{
			var sut = new Box(new Size3d(length, Unit, Unit));

			Assert.Equal(length, sut.Front.Fold.Length);
		}

		[Theory]
		[InlineData(5.0)]
		public void Depth_produces_box_front_fold_height(
			double depth)
		{
			var sut = new Box(new Size3d(Unit, Unit, depth));

			Assert.Equal(depth/2, sut.Front.Fold.Height);
		}
	}
}