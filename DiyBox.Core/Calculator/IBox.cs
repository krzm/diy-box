namespace DiyBox.Core;

public interface IBox
    : ICalculator<Size3d, IBox>
{
    BoxWall Front { get; }
    BoxWall Side { get; }
    double WallFlap { get; }
}