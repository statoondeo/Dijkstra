using System.Collections.Generic;

namespace Dijkstra
{
    public interface IVertex<T> where T : IGraphData
    {
        int Id { get; }
        T Data { get; }

        bool Visited { get; }
        void Reset();
        IEdge<T> AddEdge(IEdge<T> edge);
        bool PerformEdge(IEdge<T> edge);
        IList<IVertex<T>> Visit(IGraphConstraint<T> constraint);
    }
}

