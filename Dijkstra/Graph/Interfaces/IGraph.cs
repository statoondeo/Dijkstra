namespace Dijkstra
{
    public interface IGraph<T> where T : IGraphData, new()
    {
        IEdge<T> AddEdge(int idOrigin, int idTarget, T data);
        T FindPath(int origin, int target, T failResult, IConstraint<T> constraint);
    }
}