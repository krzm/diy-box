namespace DiyBox.Core;

public interface ITapeMarker
    : ICalculator<IBox, ITapeMarker>
{
    double GetMark(string markName);
}