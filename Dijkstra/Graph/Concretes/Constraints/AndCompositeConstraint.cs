namespace Dijkstra
{
	public class AndCompositeConstraint<T> : BaseCompositeConstraint<T> where T : IGraphData
	{
		public AndCompositeConstraint(params IGraphConstraint<T>[] constraints) : base(constraints) { }

		public override bool IsConstrainted(T graphData)
		{
			if (null == graphData) throw new ArgumentNullException(nameof(graphData));
			for (int i = 0; i < Constraints.Length; i++)
				if (!Constraints[i].IsConstrainted(graphData)) return (false);
			return (true);
		}
	}
}

