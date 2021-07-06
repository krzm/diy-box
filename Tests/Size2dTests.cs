using DiyBox.Core;
using System;
using Xunit;

namespace DiyBox.Tests
{
	public class Size2dTests
	{
		[Theory]
		[InlineData(-1, 1, "length")]
		[InlineData(1, -1, "height")]
		[InlineData(0, 1, "length")]
		[InlineData(1, 0, "height")]
		[InlineData(-1.1, 1, "length")]
		public void Size2d_throws_on_negative_and_zero(
			double length
			, double height
			, string param)
		{
			Assert.Throws<ArgumentException>(
				param
				, () => new Size2d(length, height));
		}

		[Theory]
		[InlineData(20, 10, 20, 10, true)]
		[InlineData(1.1, 1, 1.1, 1, true)]
		[InlineData(1, 1, 2, 1, false)]
		public void Size2d_equals(
			double length
			, double height
			, double length2
			, double height2
			, bool expected)
		{
			var sut = new Size2d(length, height);
			var obj = new Size2d(length2, height2);

			var actual = sut.Equals(obj);

			Assert.Equal(expected, actual);
		}

		[Fact]
		public void Size2d_equals_with_null_is_false()
		{
			var sut = new Size2d(20, 10);

			var actual = sut.Equals(null);

			Assert.False(actual);
		}

		[Fact]
		public void Size2d_equals_with_other_type_is_false()
		{
			var sut = new Size2d(20, 10);

			var actual = sut.Equals(new object());

			Assert.False(actual);
		}

		[Fact]
		public void ObjectSize_toString()
		{
			var sut = new Size2d(20, 10);

			var actual = sut.ToString();

			Assert.Equal("Size2d(Length=20, Height=10)", actual);
		}
	}
}