namespace DiyBox.Core;

public class BoxDimension 
	: Descriptor<Size3d>
{
    protected override void DefineDescription(
		Size3d size3d)
    {
        AddLine("Define X,Y,Z box coordinate system");
		AddLine("Box front is face XY");
		AddLine("X is length of the box front");
		AddLine("Y is height of the box front");
		AddLine("Z is depth of the box");
		AddLine($"Box has front of length X: {size3d.X} and height Y: {size3d.Y} and box depth is Z: {size3d.Z}");
    }
}