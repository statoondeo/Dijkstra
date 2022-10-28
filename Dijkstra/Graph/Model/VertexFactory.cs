namespace Dijkstra
{
    public class VertexFactory<T> : IVertexFactory<T> where T : class, IGraphData, new()
    {
        public IVertex<T> Create(int id) => new Vertex<T>(id);
    }
}

