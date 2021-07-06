using DiyBox.Core;
using Xunit;

namespace DiyBox.Tests
{
	public class SheetTDDTests
	{
		[Theory]
		[InlineData(2, 2, 2, 9)]
		public void Box_produces_sheet_Length(
			double length
			, double height
			, double depth
			, double sheetLength)
		{
			var sut = new Sheet(new Box(new Size3d(length, height, depth)));

			Assert.Equal(sheetLength, sut.Size.Length);
		}

		[Theory]
		[InlineData(2, 2, 2, 4)]
		public void Box_produces_sheet_Heigth(
			double length
			, double height
			, double depth
			, double sheetHeigth)
		{
			var sut = new Sheet(new Box(new Size3d(length, height, depth)));

			Assert.Equal(sheetHeigth, sut.Size.Height);
		}
	}
}