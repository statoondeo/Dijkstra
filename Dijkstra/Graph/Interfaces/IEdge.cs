namespace Dijkstra
{
    public interface IEdge<T> where T : IGraphData
    {
        IVertex<T> Origin { get; }
        IVertex<T> Target { get; }
        T Data { get; }

        bool Follow(IConstraint<T> constraint);
        void SetOrigin(IVertex<T> vertex);
    }
}

