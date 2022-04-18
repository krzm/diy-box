namespace DiyBox.Core;

public interface ISheetCalculator
    : ICalculator<string[], ISheetCalculator>
{
    Size3d BoxSize { get; }
    IBox Box { get; }
    ISheet Sheet { get; }
}
