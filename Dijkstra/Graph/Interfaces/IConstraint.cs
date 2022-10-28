namespace Dijkstra
{
    public interface IConstraint<T> where T : IGraphData
    {
        bool IsConstrainted(T graphData);
    }
}

