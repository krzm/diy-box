namespace DiyBox.Core;

public interface IBoxCompute
    : ICompute<Size3d, IBoxCompute>
{
    BoxWall? Front { get; }
    BoxWall? Side { get; }
    double WallFlap { get; }
}