using System;

namespace DiyBox.Core
{
	public class Size2d
	{
		protected const string ErrorMessage = "Positive number requaried.";

		public double Length { get; protected set; }

		public double Height { get; protected set; }

		public Size2d(
			double length
			, double height)
		{
			if (length <= 0) throw
				new ArgumentException(
					ErrorMessage
					, nameof(length));
			if (height <= 0) throw 
				new ArgumentException(
					ErrorMessage
					, nameof(height));
			Length = length;
			Height = height;
		}

		public override bool Equals(object obj)
		{
			return Equals(obj as Size2d);
		}

		public bool Equals(Size2d other)
		{
			return other != null &&
				Length == other.Length &&
				Height == other.Height;
		}

		public override int GetHashCode()
		{
			return (Length, Height).GetHashCode();
		}

		public override string ToString()
		{
			return $"Size2d(Length={Length}, Height={Height})";
		}
	}
}