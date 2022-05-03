namespace DiyBox.Core;

public interface ISheetCompute
    : ICompute<IBoxCompute, ISheetCompute>
{
    Size2d? Size { get; }
}