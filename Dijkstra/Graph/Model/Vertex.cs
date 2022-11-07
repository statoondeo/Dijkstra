namespace Dijkstra
{
    public class Vertex<T> : IVertex<T> where T : IGraphData, new()
    {
        public int Id { get; protected set; }

        public T Data { get; protected set; }
        public bool Visited { get; protected set; }

        protected IList<IEdge<T>> Edges;
		protected bool EverPerformed;
		public IEdge<T> Preceding;

		public Vertex(int id)
        {
            Id = id;
            Data = new T();
            Edges = new List<IEdge<T>>();
            Reset();
        }

        public IList<IVertex<T>> Visit(IGraphConstraint<T> constraint)
        {
            if (null == constraint) throw new ArgumentNullException(nameof(constraint));

            IList<IVertex<T>> performedVertices = new List<IVertex<T>>();
            IList<IEdge<T>> vertexEdges = Edges.Where(edge => !edge.Target.Visited).OrderBy(edge => edge.Data).ToList();
            for (int i = 0; i < vertexEdges.Count; i++)
            {
                IEdge<T> currentEdge = vertexEdges[i];
                if (currentEdge.Follow(constraint)) performedVertices.Add(currentEdge.Target);
            }
            Visited = true;
            return (performedVertices);
        }
        public IEdge<T> AddEdge(IEdge<T> edge)
        {
            if (null == edge) throw new ArgumentNullException(nameof(edge));

            edge.SetOrigin(this);
            Edges.Add(edge);
            return (edge);
        }
        public bool PerformEdge(IEdge<T> edge)
        {
            if (null == edge) throw new ArgumentNullException(nameof(edge));

            if (EverPerformed && (Data.CompareTo(edge.Origin.Data.Add(edge.Data)) < 0)) return (false);

            EverPerformed = true;
			Preceding = edge;
			Data = (T)edge.Origin.Data.Add(edge.Data);

            return (true);
        }

        public void Reset()
        {
            Data.Reset();
            Visited = false;
            EverPerformed = false;
        }
    }
}

