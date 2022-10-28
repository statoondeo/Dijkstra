namespace Dijkstra
{
	public class OrCompositeConstraint<T> : BaseCompositeConstraint<T> where T : IGraphData
	{
		public OrCompositeConstraint(List<IConstraint<T>> constraints) : base(constraints) { }

		public override bool IsConstrainted(T graphData)
		{
			if (null == graphData) throw new ArgumentNullException(nameof(graphData));
			for (int i = 0; i < Constraints.Count; i++)
				if (Constraints[i].IsConstrainted(graphData)) return (true);
			return (false);
		}
	}
}

