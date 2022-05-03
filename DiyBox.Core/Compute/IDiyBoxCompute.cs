namespace DiyBox.Core;

public interface IDiyBoxCompute
    : ICompute<string[], IDiyBoxCompute>
{
    IBoxToSheetCompute? SheetCalculator { get; }
    IWasteCompute? Waste { get; }
    ITapeMeasureCompute? HorizontalTapeMarker { get; }
    ITapeMeasureCompute? VerticalFrontTapeMarker { get; }
    ITapeMeasureCompute? VerticalSideTapeMarker { get; }
}