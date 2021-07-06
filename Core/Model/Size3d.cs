using System;

namespace Core
{
	public class Size3d : Size2d
	{
		public double Depth { get; private set; }

		public Size3d(
			double length
			, double height
			, double depth) : base(length, height)
		{
			if (depth <= 0) throw 
				new ArgumentException(
					ErrorMessage
					, nameof(depth));
			Depth = depth;
		}

		public override bool Equals(object obj)
		{
			return Equals(obj as Size3d);
		}

		public bool Equals(Size3d other)
		{
			return other != null &&
				base.Equals(other) &&
				Depth == other.Depth;
		}

		public override int GetHashCode()
		{
			return (Length, Height, Depth).GetHashCode();
		}

		public override string ToString()
		{
			return $"Size3d(Length={Length}, Height={Height}, Depth={Depth})";
		}
	}
}