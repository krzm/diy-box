namespace DiyBox.Core;

public interface ITapeMarker
    : ICalculator<object, ITapeMarker>
{
    double GetMark(string markName);

    double[] GetMarks();
}