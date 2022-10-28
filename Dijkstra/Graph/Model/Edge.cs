namespace Dijkstra
{
    public class Edge<T> : IEdge<T> where T : IGraphData
    {
        public IVertex<T> Origin { get; protected set; }
        public IVertex<T> Target { get; protected set; }
        public T Data { get; protected set; }

        public Edge(IVertex<T> target, T data)
        {
            Target = target ?? throw new ArgumentNullException(nameof(target));
            Data = data ?? throw new ArgumentNullException(nameof(data));
        }

        public void SetOrigin(IVertex<T> origin) => Origin = origin ?? throw new ArgumentNullException(nameof(origin));
        public bool Follow(IConstraint<T> constraint) => !constraint.IsConstrainted((T)Data.Add(Origin.Data)) && Target.PerformEdge(this);
    }
}

