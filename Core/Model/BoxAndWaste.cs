namespace DiyBox.Core
{
	public class BoxAndWaste
	{
		public Box Box { get; private set; }
		public Waste Waste { get; private set; }

		public BoxAndWaste(
			Box box
			, Waste waste)
		{
			Box = box;
			Waste = waste;
		}
	}
}