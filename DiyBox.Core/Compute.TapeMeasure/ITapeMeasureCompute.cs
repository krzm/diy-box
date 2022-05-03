namespace DiyBox.Core;

public interface ITapeMeasureCompute
    : ICompute<object, ITapeMeasureCompute>
{
    double GetMark(string markName);

    object[] GetMarks();
}