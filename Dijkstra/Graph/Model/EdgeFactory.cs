using Dijkstra.Graph.Model;

namespace Dijkstra
{
    public class EdgeFactory<T> : IEdgeFactory<T> where T : class, IGraphData, new()
    {
        public IEdge<T> Create(IVertex<T> targetVertex, T data) => new Edge<T>(targetVertex, data);
    }
}

