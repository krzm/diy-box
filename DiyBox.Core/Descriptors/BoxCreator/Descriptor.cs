using System.Text;

namespace DiyBox.Core;

public abstract class Descriptor
    : IDescriptor
{
	private readonly ITapeMarker tapeMarker;
	private StringBuilder sb;

    protected Descriptor(
		ITapeMarker tapeMarker
	)
	{
        this.tapeMarker = tapeMarker;
    }

    public string GetDescription(object data = null)
	{
		var bc = (IBoxCalculator)data;
		sb = new StringBuilder();
		DefineDescription(bc.SheetCalculator.Box, bc.Waste);
		return sb.ToString();		
	}

    protected abstract void DefineDescription(IBox box, IWaste waste);

    protected void Add(string line)
	{
		sb.AppendLine(line);
	}

	protected void Add(string lineFormat
		, double cm
		, string markKey)
	{
		sb.AppendFormat(lineFormat, cm);
		Mark(markKey);
	}

    private void Mark(string markKey)
    {
        sb.AppendLine($"(Measuring tape {tapeMarker.GetMark(markKey)})");
    }
}