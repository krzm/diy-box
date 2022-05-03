namespace DiyBox.Core;

public interface IWasteCompute
	: ICompute<IBoxToSheetCompute, IWasteCompute> 
{
    double WasteHeight { get; }
    bool IsFrontWaste { get; }
    bool IsSideWaste { get; }
}