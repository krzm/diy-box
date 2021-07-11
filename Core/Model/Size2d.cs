using System;

namespace DiyBox.Core
{
	public class Size2d
	{
		protected const string ErrorMessage = "Positive number requaried.";

		public double Length { get; protected set; }

		public double Width { get; protected set; }

		public Size2d(
			double length
			, double width)
		{
			if (length <= 0) throw
				new ArgumentException(
					ErrorMessage
					, nameof(length));
			if (width <= 0) throw 
				new ArgumentException(
					ErrorMessage
					, nameof(width));
			Length = length;
			Width = width;
		}

		public override bool Equals(object obj)
		{
			return Equals(obj as Size2d);
		}

		public bool Equals(Size2d other)
		{
			return other != null &&
				Length == other.Length &&
				Width == other.Width;
		}

		public override int GetHashCode()
		{
			return (Length, Width).GetHashCode();
		}

		public override string ToString()
		{
			return $"Size2d({nameof(Length)}={Length}, {nameof(Width)}={Width})";
		}
	}
}