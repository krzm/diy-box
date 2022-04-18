using DiyBox.Core;
using System;
using Xunit;

namespace DiyBox.Tests;

public class Size3dTests
{
	const string x = nameof(Size3d.X);
	const string y = nameof(Size3d.Y);
	const string z = nameof(Size3d.Z);

	[Theory]
	[InlineData(-1, 1, 1, x)]
	[InlineData(1, -1, 1, y)]
	[InlineData(1, 1, -1, z)]
	[InlineData(0, 1, 1, x)]
	[InlineData(1, 0, 1, y)]
	[InlineData(1, 1, 0, z)]
	[InlineData(1, 1, -1.1, z)]
	public void Size3d_throws_on_negative_and_zero(
		double length
		, double heigth
		, double depth
		, string param)
	{
		Assert.Throws<ArgumentException>(
			param.ToLowerInvariant()
			, () => new Size3d(length, heigth, depth));
	}

	[Theory]
	[InlineData(20, 10, 5, 20, 10, 5, true)]
	[InlineData(1, 1.1, 1, 1, 1.1, 1, true)]
	[InlineData(1, 1, 1, 2, 1, 1, false)]
	public void Size3d_equals(
		double length
		, double heigth
		, double depth
		, double length2
		, double heigth2
		, double depth2
		, bool expected)
	{
		var sut = new Size3d(length, heigth, depth);
		var obj = new Size3d(length2, heigth2, depth2);

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

		Assert.Equal("Size3d(X=20, Y=10, Z=5)", actual);
	}
}