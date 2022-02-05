namespace DiyBox.Core;

public class BoxWall
{
	public Size2d Wall { get; private set; }

	public Size2d Fold { get; private set; }

	public BoxWall(
		Size2d wall
		, Size2d fold)
	{
		Wall = wall;
		Fold = fold;
	}
}