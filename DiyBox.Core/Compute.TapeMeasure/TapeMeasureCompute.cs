namespace DiyBox.Core;

public abstract class TapeMeasureCompute
    : ITapeMeasureCompute
{
    private readonly Dictionary<string, double> marks;

    protected TapeMeasureCompute()
    {
        marks = new Dictionary<string, double>();
    }

    public ITapeMeasureCompute Compute(
        object data)
    {
        marks.Clear();
        return CalcMarks(data);
    }

    protected abstract ITapeMeasureCompute CalcMarks(
        object data);

    public double GetMark(string markName)
    {
        return marks[markName];
    }

    public object[] GetMarks()
    {
        return marks.Select(m=> (object)m.Value).ToArray();
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