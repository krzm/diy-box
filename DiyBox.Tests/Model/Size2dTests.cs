using DiyBox.Core;
using System;
using Xunit;

namespace DiyBox.Tests;

public class Size2dTests
{
	const string x = nameof(Size2d.X);
	const string y = nameof(Size2d.Y);

	[Theory]
	[InlineData(-1, 1, x)]
	[InlineData(1, -1, y)]
	[InlineData(0, 1, x)]
	[InlineData(1, 0, y)]
	[InlineData(-1.1, 1, x)]
	public void Size2d_throws_on_negative_and_zero(
		double length
		, double height
		, string param)
	{
		var paramName = param.ToLowerInvariant();
		var ex = Assert.Throws<ArgumentException>(
			paramName
			, () => new Size2d(length, height));
		Assert.Equal(
			string.Join(
				" "
				, "Positive number requaried"
				, $"(Parameter '{paramName}')"
			)
			, ex.Message);
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
		var sut1 = new Size2d(length, height);
		var sut2 = new Size2d(length2, height2);

		var actual = sut1.Equals(sut2);

		Assert.Equal(expected, actual);
	}

	[Fact]
	public void Size2d_equals_with_null_is_false()
	{
		var sut = new Size2d(20, 10);

		var actual = sut.Equals(null!);

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

		Assert.Equal("Size2d(X=20, Y=10)", actual);
	}
}