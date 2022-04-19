using System.Collections.Generic;

namespace DiyBox.Core;

public abstract class TapeMarker
    : ITapeMarker
{
    private Dictionary<string, double> marks;

    protected TapeMarker()
    {
        marks = new Dictionary<string, double>();
    }

    public abstract ITapeMarker Calculate(IBoxCalculator input);

    public double GetMark(string markName)
    {
        return marks[markName];
    }

    protected void Add(
        string markKey
        , double cm)
    {
        marks.Add(
            markKey
            , cm);
    }

    protected void Add(
        string markKey
        , string previousKey
        , double cm)
    {
        marks.Add(
            markKey
            , marks[previousKey]
                + cm);
    }
}