using DiyBox.Core;
using System;
using Xunit;

namespace DiyBox.Tests
{
	public class Size3dTests
	{
		[Theory]
		[InlineData(-1, 1, 1, "length")]
		[InlineData(1, -1, 1, "width")]
		[InlineData(1, 1, -1, "height")]
		[InlineData(0, 1, 1, "length")]
		[InlineData(1, 0, 1, "width")]
		[InlineData(1, 1, 0, "height")]
		[InlineData(1, 1, -1.1, "height")]
		public void Size3d_throws_on_negative_and_zero(
			double length
			, double width
			, double height
			, string param)
		{
			Assert.Throws<ArgumentException>(
				param
				, () => new Size3d(length, width, height));
		}

		[Theory]
		[InlineData(20, 10, 5, 20, 10, 5, true)]
		[InlineData(1, 1.1, 1, 1, 1.1, 1, true)]
		[InlineData(1, 1, 1, 2, 1, 1, false)]
		public void Size3d_equals(
			double length
			, double width
			, double height
			, double length2
			, double width2
			, double height2
			, bool expected)
		{
			var sut = new Size3d(length, width, height);
			var obj = new Size3d(length2, width2, height2);

			var actual = sut.Equals(obj);

			Assert.Equal(expected, actual);
		}

		[Fact]
		public void Size3d_equals_with_null_is_false()
		{
			var sut = new Size3d(20, 10, 5);

			var actual = sut.Equals(null);

			Assert.False(actual);
		}

		[Fact]
		public void Size3d_equals_with_other_type_is_false()
		{
			var sut = new Size3d(20, 10, 5);

			var actual = sut.Equals(new object());

			Assert.False(actual);
		}

		[Fact]
		public void Size3d_toString()
		{
			var sut = new Size3d(20, 10, 5);

			var actual = sut.ToString();

			Assert.Equal("Size3d(Length=20, Width=10, Height=5)", actual);
		}
	}
}