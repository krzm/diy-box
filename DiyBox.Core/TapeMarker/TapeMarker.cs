using System.Collections.Generic;
using System.Linq;

namespace DiyBox.Core;

public abstract class TapeMarker
    : ITapeMarker
{
    private readonly Dictionary<string, double> marks;

    protected TapeMarker()
    {
        marks = new Dictionary<string, double>();
    }

    public ITapeMarker Calculate(
        object data)
    {
        marks.Clear();
        return CalcMarks(data);
    }

    protected abstract ITapeMarker CalcMarks(
        object data);

    public double GetMark(string markName)
    {
        return marks[markName];
    }

    public double[] GetMarks()
    {
        return marks.Values.ToArray();
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