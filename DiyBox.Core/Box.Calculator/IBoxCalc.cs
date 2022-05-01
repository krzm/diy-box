namespace DiyBox.Core;

public interface IBoxCalc
    : ICalculator<Size3d, IBoxCalc>
{
    BoxWall? Front { get; }
    BoxWall? Side { get; }
    double WallFlap { get; }
}