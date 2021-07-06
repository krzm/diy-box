using DiyBox.Core;
using System;
using Xunit;

namespace DiyBox.Tests
{
	public class DiyBoxParserTDDTests
	{
		[Theory]
		[InlineData(new object[] {
			new string[] { null } })]
		[InlineData(new object[] {
			new string[] { "" } })]
		[InlineData(new object[] {
			new string[] { "20" } })]
		[InlineData(new object[] {
			new string[] { "20", "10" } })]
		[InlineData(new object[] {
			new string[] { "20", "10", "5", "20" } })]
		public void Invalid_number_of_args_throws(
			string[] args)
		{
			var sut = new DiyBoxParser();

			Assert.Throws<ArgumentException>("args", () => sut.Parse(args));
		}

		[Theory]
		[InlineData(new object[] {
			new string[] { "a", "10", "5" }
			, "Length"})]
		[InlineData(new object[] {
			new string[] { "20", "a", "5" }
			, "Height"})]
		[InlineData(new object[] {
			new string[] { "20", "10", "a" }
			, "Depth"})]
		public void Input_invalid_format_throws(
			string[] args
			, string argName)
		{
			var sut = new DiyBoxParser();

			Assert.Throws<ArgumentException>(argName, () => sut.Parse(args));
		}

		[Theory]
		[InlineData(new object[] {
			new string[] { "0.1", "0.1", "0.1" }
			, 0.1
			, 0.1
			, 0.1 })]
		[InlineData(new object[] { 
			new string[] { "20", "10", "5" }
			, 20
			, 10
			, 5 })]
		public void Valid_input_produces_parsed_data(
			string[] args
			, double length
			, double height
			, double depth)
		{
			var sut = new DiyBoxParser();

			var acctual = sut.Parse(args);

			Assert.Equal(new Size3d(length, height, depth), acctual);
		}
	}
}