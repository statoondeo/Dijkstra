using System;

namespace Dijkstra
{
    public interface IGraphData : IComparable<IGraphData>
    {
        IGraphData Add(params IGraphData[] data);
        void Reset();
    }
}

