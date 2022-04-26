using System.Text;

namespace DiyBox.Core;

public abstract class Descriptor<TData>
    : IDescriptor
{
	private readonly StringBuilder sb;

	public Descriptor()
	{
		sb = new StringBuilder();
	}

    public string GetDescription(object data = null)
	{
		var dataType = (TData)data;
		sb.Clear();
		DefineDescription(dataType);
		return sb.ToString();		
	}

    protected abstract void DefineDescription(TData data);

    protected void Add(string line)
	{
		sb.AppendLine(line);
	}
    
    protected void Add<TType>(
		string lineFormat
		, params TType[] dims
	)
	{
		sb.AppendFormat(lineFormat, dims);
	}
}