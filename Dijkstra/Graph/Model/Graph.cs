namespace Dijkstra
{
    public class Graph<T> : IGraph<T> where T : class, IGraphData, new()
    {
        protected IDictionary<int, IVertex<T>> Vertices;
        protected IVertexFactory<T> VertexFactory;
        protected IEdgeFactory<T> EdgeFactory;

        public Graph(IVertexFactory<T> vertexFactory, IEdgeFactory<T> edgeFactory)
        {
            Vertices = new Dictionary<int, IVertex<T>>();
            VertexFactory = vertexFactory ?? throw new ArgumentNullException(nameof(vertexFactory));
            EdgeFactory = edgeFactory ?? throw new ArgumentNullException(nameof(edgeFactory));
        }

        protected virtual IVertex<T> AddVertex(int id)
        {
            IVertex<T> vertex = VertexFactory.Create(id);
            Vertices.Add(id, vertex);
            return (vertex);
        }
        protected virtual IVertex<T> GetVertex(int id) => Vertices.ContainsKey(id) ? Vertices[id] : null;

        public virtual IEdge<T> AddEdge(int idOrigin, int idTarget, T data)
        {
            IVertex<T> originVertex = GetVertex(idOrigin) ?? AddVertex(idOrigin);
            IVertex<T> targetVertex = GetVertex(idTarget) ?? AddVertex(idTarget);
            return (originVertex.AddEdge(EdgeFactory.Create(targetVertex, data)));
        }
        public virtual T FindPath(int origin, int target, T failResult, IGraphConstraint<T> constraint)
        {
            IVertex<T> originVertex = GetVertex(origin);
            if (null == originVertex) throw new ArgumentOutOfRangeException(nameof(originVertex));

            IVertex<T> targetVertex = GetVertex(target);
            if (null == targetVertex) throw new ArgumentOutOfRangeException(nameof(targetVertex));
            if (null == failResult) throw new ArgumentNullException(nameof(failResult));
            if (null == constraint) throw new ArgumentNullException(nameof(constraint));

            foreach (IVertex<T> vertex in Vertices.Values) vertex.Reset();

            HashSet<IVertex<T>> verticesToVisit = new() { originVertex };
            bool found = false;
            while (!found && (verticesToVisit.Count > 0))
            {
                IVertex<T> currentVertex = null;
                foreach (IVertex<T> vertex in verticesToVisit)
                    if ((null == currentVertex) || (vertex.Data.CompareTo(currentVertex.Data) < 0)) currentVertex = vertex;
                verticesToVisit.Remove(currentVertex);
                verticesToVisit.UnionWith(currentVertex.Visit(constraint));
                found = currentVertex == targetVertex;
            }
            return (found ? targetVertex.Data : failResult);
        }
    }
}

