﻿using DiyBox.Core;
using Xunit;

namespace DiyBox.Tests;

public class BoxWallFlapTests
{
	private const double Unit = .1;

	[Theory]
	[InlineData(80, 10)]
	[InlineData(40, 10)]
	[InlineData(30, 7)]
	[InlineData(20, 5)]
	[InlineData(15, 5)]
	public void Wall_flap_size_depending_on_length(
		double length
		, int flop)
	{
		var sut = new Box(new Size3d(length, Unit, Unit));

		Assert.Equal(flop, sut.WallFlap);
	}
}