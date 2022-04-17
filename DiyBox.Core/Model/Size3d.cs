using System;

namespace DiyBox.Core;

public class Size3d : Size2d
{
	public double Z { get; private set; }

	public Size3d(
		double x
		, double y
		, double z) : base(x, y)
	{
		if (z <= 0) throw 
			new ArgumentException(
				ErrorMessage
				, nameof(z));
		Z = z;
	}

	public override bool Equals(object obj)
	{
		return Equals(obj as Size3d);
	}

	public bool Equals(Size3d other)
	{
		return other != null &&
			base.Equals(other) &&
			Z == other.Z;
	}

	public override int GetHashCode()
	{
		return (X, Y, Z).GetHashCode();
	}

	public override string ToString()
	{
		return $"Size3d({nameof(X)}={X}, {nameof(Y)}={Y}, {nameof(Z)}={Z})";
	}
}