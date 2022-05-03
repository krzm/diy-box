namespace DiyBox.Core;

public interface IBoxToSheetCompute
    : ICompute<string[], IBoxToSheetCompute>
{
    Size3d? BoxSize { get; }
    IBoxCompute? Box { get; }
    ISheetCompute? Sheet { get; }
}