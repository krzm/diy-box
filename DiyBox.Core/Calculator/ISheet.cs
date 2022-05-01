namespace DiyBox.Core;

public interface ISheet
    : ICalculator<IBoxCalc, ISheet>
{
    Size2d? Size { get; }
}