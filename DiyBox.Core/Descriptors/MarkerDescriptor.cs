namespace DiyBox.Core;

public abstract class MarkerDescriptor<TData>
    : Descriptor<TData>
{
	private readonly ITapeMeasureCompute tapeMarker;

    protected MarkerDescriptor(
		ITapeMeasureCompute tapeMarker
	)
	{
        this.tapeMarker = tapeMarker;
    }

	protected void Add(string lineFormat
		, double cm
		, string markKey)
	{
		Add(lineFormat, cm);
		Mark(markKey);
	}

    private void Mark(string markKey)
    {
        AddLine($" (Measuring tape {tapeMarker.GetMark(markKey)})");
    }
}