namespace DiyBox.Core;

public interface IBoxCalculator
    : ICalculator<string[], IBoxCalculator>
{
    ISheetCalculator SheetCalculator { get; }
    IWaste Waste { get; }
    ITapeMarker HorizontalTapeMarker { get; }
}