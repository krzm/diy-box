namespace DiyBox.Core;

public interface ISheet
    : ICalculator<IBox, ISheet>
{
    Size2d Size { get; }
}