using DiyBox.Core;
using System;
using Xunit;

namespace DiyBox.Tests
{
	public class Size3dTests
	{
		[Theory]
		[InlineData(-1, 1, 1, "length")]
		[InlineData(1, -1, 1, "height")]
		[InlineData(1, 1, -1, "depth")]
		[InlineData(0, 1, 1, "length")]
		[InlineData(1, 0, 1, "height")]
		[InlineData(1, 1, 0, "depth")]
		[InlineData(1, 1, -1.1, "depth")]
		public void Size3d_throws_on_negative_and_zero(
			double length
			, double height
			, double depth
			, string param)
		{
			Assert.Throws<ArgumentException>(
				param
				, () => new Size3d(length, height, depth));
		}

		[Theory]
		[InlineData(20, 10, 5, 20, 10, 5, true)]
		[InlineData(1, 1.1, 1, 1, 1.1, 1, true)]
		[InlineData(1, 1, 1, 2, 1, 1, false)]
		public void Size3d_equals(
			double length
			, double height
			, double depth
			, double length2
			, double height2
			, double depth2
			, bool expected)
		{
			var sut = new Size3d(length, height, depth);
			var obj = new Size3d(length2, height2, depth2);

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

			Assert.Equal("Size3d(Length=20, Height=10, Depth=5)", actual);
		}
	}
}