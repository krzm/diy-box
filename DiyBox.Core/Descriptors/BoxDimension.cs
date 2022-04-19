namespace DiyBox.Core;

public class BoxDimension 
	: Descriptor<Size3d>
{
    protected override void DefineDescription(
		Size3d size3d)
    {
        Add("Define X,Y,Z box coordinate system");
		Add("Box front is face XY");
		Add("X is length of the box front");
		Add("Y is height of the box front");
		Add("Z is depth of the box");
		Add($"Box has front of length X: {size3d.X} and height Y: {size3d.Y} and box depth is Z: {size3d.Z}");
    }
}