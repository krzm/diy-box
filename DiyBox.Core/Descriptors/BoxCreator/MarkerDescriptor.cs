namespace DiyBox.Core;

public abstract class MarkerDescriptor<TData>
    : Descriptor<TData>
{
	private readonly ITapeMarker tapeMarker;

    protected MarkerDescriptor(
		ITapeMarker tapeMarker
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
        Add($" (Measuring tape {tapeMarker.GetMark(markKey)})");
    }
}