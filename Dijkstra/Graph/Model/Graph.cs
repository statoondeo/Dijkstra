namespace Dijkstra
{
    public class Graph<T> : IGraph<T> where T : class, IGraphData, new()
    {
        protected IDictionary<int, IVertex<T>> Nodes;
        protected IVertexFactory<T> VertexFactory;
        protected IEdgeFactory<T> EdgeFactory;

        public Graph(IVertexFactory<T> vertexFactory, IEdgeFactory<T> edgeFactory)
        {
            Nodes = new Dictionary<int, IVertex<T>>();
            VertexFactory = vertexFactory ?? throw new ArgumentNullException(nameof(vertexFactory));
            EdgeFactory = edgeFactory ?? throw new ArgumentNullException(nameof(edgeFactory));
        }

        protected virtual IVertex<T> AddNode(int id)
        {
            IVertex<T> node = VertexFactory.Create(id);
            Nodes.Add(id, node);
            return (node);
        }
        protected virtual IVertex<T> GetNode(int id) => Nodes.ContainsKey(id) ? Nodes[id] : null;

        public virtual IEdge<T> AddEdge(int idOrigin, int idTarget, T data)
        {
            IVertex<T> originVertex = GetNode(idOrigin) ?? AddNode(idOrigin);
            IVertex<T> targetVertex = GetNode(idTarget) ?? AddNode(idTarget);
            return (originVertex.AddEdge(EdgeFactory.Create(targetVertex, data)));
        }

        public virtual T FindPath(int origin, int target, T failResult, IConstraint<T> constraint)
        {
            IVertex<T> originNode = GetNode(origin);
            if (null == originNode) throw new ArgumentOutOfRangeException(nameof(originNode));

            IVertex<T> targetNode = GetNode(target);
            if (null == targetNode) throw new ArgumentOutOfRangeException(nameof(targetNode));
            if (null == failResult) throw new ArgumentNullException(nameof(failResult));
            if (null == constraint) throw new ArgumentNullException(nameof(constraint));

            foreach (IVertex<T> vertex in Nodes.Values) vertex.Reset();

            HashSet<IVertex<T>> nodesToVisit = new HashSet<IVertex<T>>() { originNode };
            bool found = false;
            while (!found && (nodesToVisit.Count > 0))
            {
                IVertex<T> currentNode = null;
                foreach (IVertex<T> vertex in nodesToVisit)
                    if ((null == currentNode) || (vertex.Data.CompareTo(currentNode.Data) < 0)) currentNode = vertex;
                nodesToVisit.Remove(currentNode);
                nodesToVisit.UnionWith(currentNode.Visit(constraint));
                found = currentNode == targetNode;
            }
            if (found)
            {
                Vertex<T> vertex = (Vertex<T>)targetNode;
                while (vertex != null)
                {
                    Console.Write($" {vertex.Id}");
                    vertex = (Vertex<T>)vertex.Preceding?.Origin;
                }
                Console.WriteLine();
            }
            return (found ? targetNode.Data : failResult);
        }
    }
}

