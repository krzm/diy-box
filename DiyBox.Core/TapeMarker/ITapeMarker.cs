namespace DiyBox.Core;

public interface ITapeMarker
    : ICalculator<IBoxCalculator, ITapeMarker>
{
    double GetMark(string markName);
}