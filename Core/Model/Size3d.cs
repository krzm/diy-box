using System;

namespace DiyBox.Core
{
	public class Size3d : Size2d
	{
		public double Height { get; private set; }

		public Size3d(
			double length
			, double width
			, double height) : base(length, width)
		{
			if (height <= 0) throw 
				new ArgumentException(
					ErrorMessage
					, nameof(height));
			Height = height;
		}

		public override bool Equals(object obj)
		{
			return Equals(obj as Size3d);
		}

		public bool Equals(Size3d other)
		{
			return other != null &&
				base.Equals(other) &&
				Height == other.Height;
		}

		public override int GetHashCode()
		{
			return (Length, Width, Height).GetHashCode();
		}

		public override string ToString()
		{
			return $"Size3d({nameof(Length)}={Length}, {nameof(Width)}={Width}, {nameof(Height)}={Height})";
		}
	}
}