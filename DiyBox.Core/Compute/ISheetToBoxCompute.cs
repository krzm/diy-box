namespace DiyBox.Core;

public interface ISheetToBoxCompute
    : ICompute<string[], ISheetToBoxCompute>
{
    Size2d? SheetSize { get; }
    IBoxCompute? Box { get; }
    ISheetCompute? Sheet { get; }
    Size3d? ResultBoxSize { get; }
}