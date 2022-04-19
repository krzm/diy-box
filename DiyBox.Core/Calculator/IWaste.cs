namespace DiyBox.Core;

public interface IWaste
	: ICalculator<ISheetCalculator, IWaste> 
{
    double WasteHeight { get; }
    bool IsFrontWaste { get; }
    bool IsSideWaste { get; }
}