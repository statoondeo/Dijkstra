namespace Dijkstra
{
    public abstract class BaseCompositeConstraint<T> : IGraphConstraint<T> where T : IGraphData
    {
        protected IGraphConstraint<T>[] Constraints;

        protected BaseCompositeConstraint(params IGraphConstraint<T>[] constraints) => Constraints = constraints ?? throw new ArgumentNullException(nameof(constraints));

        public abstract bool IsConstrainted(T graphData);
    }
}

